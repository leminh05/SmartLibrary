namespace SmartLibrary;

public partial class MainForm : Form
{
    private readonly Library library = Library.CreateSample();

    public MainForm()
    {
        InitializeComponent();
        RefreshAll();
    }

    private void RefreshAll()
    {
        dgvItems.DataSource = library.Search(txtSearch.Text);
        cboItem.DataSource = library.Items.ToList();
        cboMember.DataSource = library.Members.ToList();
        dgvMembers.DataSource = library.Members.ToList();
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

    private void btnCheckOut_Click(object sender, EventArgs e)
    {
        if (cboItem.SelectedItem is not LibraryItem item || cboMember.SelectedItem is not Member member) return;
        Run(() =>
        {
            library.CheckOut(item.Id, member.Id, DateTime.Today);
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
}
