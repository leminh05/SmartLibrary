namespace SmartLibrary;

public partial class MainForm : Form
{
    private readonly Library library = Library.CreateSample();

    public MainForm()
    {
        InitializeComponent();
        // Demo data: one loan made 20 days ago, so the dashboard and the search grid show an overdue item.
        library.CheckOut("B002", "S002", DateTime.Today.AddDays(-20));
        RefreshAll();
    }

    private void RefreshAll()
    {
        dgvItems.DataSource = library.Search(txtSearch.Text);
        cboItem.DataSource = library.Items.ToList();
        cboMember.DataSource = library.Members.ToList();
        dgvMembers.DataSource = library.Members.ToList();
        RefreshDashboard();
    }

    private void RefreshDashboard()
    {
        var overdue = library.Overdue(DateTime.Today);
        lblTotal.Text = $"Total items: {library.Items.Count}";
        lblBorrowed.Text = $"Borrowed: {library.BorrowedCount}";
        lblOverdue.Text = $"Overdue: {overdue.Count}";
        lblFines.Text = $"Unpaid fines: {library.TotalFinesOwed:N0} VND";
        lblOverdue.ForeColor = overdue.Count > 0 ? Color.DarkRed : SystemColors.ControlText;
        // Each object answers GenerateReport() in its own way (interface polymorphism).
        txtReport.Text = string.Join(Environment.NewLine, library.Reportables.Select(r => r.GenerateReport()));
    }

    // Runs a library action, shows its result, and turns rule violations into a friendly message.
    private void Run(Func<string> action)
    {
        try
        {
            lblResult.Text = action();
            RefreshAll();
        }
        catch (Exception ex) when (ex is InvalidOperationException or ArgumentException)
        {
            MessageBox.Show(ex.Message, "Smart Library", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void txtSearch_TextChanged(object sender, EventArgs e) =>
        dgvItems.DataSource = library.Search(txtSearch.Text);

    private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.CellStyle != null && dgvItems.Rows[e.RowIndex].DataBoundItem is LibraryItem item && item.IsOverdue(DateTime.Today))
        {
            e.CellStyle.BackColor = Color.MistyRose;
            e.CellStyle.ForeColor = Color.DarkRed;
        }
    }

    private void btnAddItem_Click(object sender, EventArgs e)
    {
        using var dialog = new AddItemForm();
        if (dialog.ShowDialog(this) == DialogResult.OK && dialog.CreatedItem is LibraryItem item)
            Run(() =>
            {
                library.AddItem(item);
                return $"Added {item.Type} \"{item.Title}\".";
            });
    }

    private void btnItemReport_Click(object sender, EventArgs e)
    {
        if (dgvItems.CurrentRow?.DataBoundItem is LibraryItem item)
            MessageBox.Show(item.GenerateReport(), "Item Report");
    }

    private void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (cboItem.SelectedItem is not LibraryItem item || cboMember.SelectedItem is not Member member) return;
        Run(() =>
        {
            library.CheckOut(item.Id, member.Id, dtpBorrow.Value);
            return $"{member.Name} borrowed \"{item.Title}\". Due {item.DueDate:dd/MM/yyyy} ({item.LoanDays} days).";
        });
    }

    private void btnCheckIn_Click(object sender, EventArgs e)
    {
        if (cboItem.SelectedItem is not LibraryItem item) return;
        Run(() =>
        {
            int daysLate = item.DaysLate(dtpReturn.Value);
            decimal fee = library.CheckIn(item.Id, dtpReturn.Value);
            string result = $"\"{item.Title}\" returned, {daysLate} day(s) late. Late fee: {fee:N0} VND.";
            if (item is DigitalMedia { AccessRevoked: true })
                result += " Digital access was revoked automatically.";
            return result;
        });
    }

    private void btnAddMember_Click(object sender, EventArgs e) => Run(() =>
    {
        library.AddMember(txtMemberId.Text, txtMemberName.Text);
        txtMemberId.Clear();
        txtMemberName.Clear();
        return "Member added.";
    });

    private void btnRemoveMember_Click(object sender, EventArgs e)
    {
        if (dgvMembers.CurrentRow?.DataBoundItem is not Member member) return;
        if (MessageBox.Show($"Remove {member.Name}?", "Smart Library", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
        Run(() =>
        {
            library.RemoveMember(member.Id);
            return $"{member.Name} removed.";
        });
    }

    private void btnPayFine_Click(object sender, EventArgs e)
    {
        if (dgvMembers.CurrentRow?.DataBoundItem is not Member member) return;
        Run(() =>
        {
            library.PayFine(member.Id, nudPayAmount.Value);
            string message = $"{member.Name} paid {nudPayAmount.Value:N0} VND. Still owes {member.FinesOwed:N0} VND.";
            MessageBox.Show(message, "Payment");
            return message;
        });
    }

    private void btnMemberReport_Click(object sender, EventArgs e)
    {
        if (dgvMembers.CurrentRow?.DataBoundItem is Person person)
            MessageBox.Show(person.GenerateReport(), $"{person.Role} Details");
    }
}
