namespace SmartLibrary;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        tabMain = new TabControl();
        tabDashboard = new TabPage();
        lblTotal = new Label();
        lblBorrowed = new Label();
        lblOverdue = new Label();
        lblFines = new Label();
        txtReport = new TextBox();
        btnResetData = new Button();
        tabSearch = new TabPage();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnAddItem = new Button();
        btnItemReport = new Button();
        dgvItems = new DataGridView();
        tabLoans = new TabPage();
        lblItem = new Label();
        cboItem = new ComboBox();
        lblMember = new Label();
        cboMember = new ComboBox();
        lblBorrow = new Label();
        dtpBorrow = new DateTimePicker();
        btnCheckOut = new Button();
        lblReturn = new Label();
        dtpReturn = new DateTimePicker();
        btnCheckIn = new Button();
        lblResult = new Label();
        tabMembers = new TabPage();
        dgvMembers = new DataGridView();
        lblMemberId = new Label();
        txtMemberId = new TextBox();
        lblMemberName = new Label();
        txtMemberName = new TextBox();
        btnAddMember = new Button();
        btnRemoveMember = new Button();
        lblPay = new Label();
        nudPayAmount = new NumericUpDown();
        btnPayFine = new Button();
        btnMemberReport = new Button();
        tabMain.SuspendLayout();
        tabDashboard.SuspendLayout();
        tabSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
        tabLoans.SuspendLayout();
        tabMembers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPayAmount).BeginInit();
        SuspendLayout();
        //
        // tabMain
        //
        tabMain.Controls.Add(tabDashboard);
        tabMain.Controls.Add(tabSearch);
        tabMain.Controls.Add(tabLoans);
        tabMain.Controls.Add(tabMembers);
        tabMain.Dock = DockStyle.Fill;
        tabMain.Location = new Point(0, 0);
        tabMain.Name = "tabMain";
        tabMain.SelectedIndex = 0;
        tabMain.Size = new Size(884, 511);
        tabMain.TabIndex = 0;
        //
        // tabDashboard
        //
        tabDashboard.Controls.Add(lblTotal);
        tabDashboard.Controls.Add(lblBorrowed);
        tabDashboard.Controls.Add(lblOverdue);
        tabDashboard.Controls.Add(lblFines);
        tabDashboard.Controls.Add(txtReport);
        tabDashboard.Controls.Add(btnResetData);
        tabDashboard.Location = new Point(4, 24);
        tabDashboard.Name = "tabDashboard";
        tabDashboard.Padding = new Padding(3);
        tabDashboard.Size = new Size(876, 483);
        tabDashboard.TabIndex = 0;
        tabDashboard.Text = "Dashboard";
        tabDashboard.UseVisualStyleBackColor = true;
        //
        // lblTotal
        //
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotal.Location = new Point(12, 12);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(100, 21);
        lblTotal.TabIndex = 0;
        lblTotal.Text = "Total items:";
        //
        // lblBorrowed
        //
        lblBorrowed.AutoSize = true;
        lblBorrowed.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblBorrowed.Location = new Point(220, 12);
        lblBorrowed.Name = "lblBorrowed";
        lblBorrowed.Size = new Size(85, 21);
        lblBorrowed.TabIndex = 1;
        lblBorrowed.Text = "Borrowed:";
        //
        // lblOverdue
        //
        lblOverdue.AutoSize = true;
        lblOverdue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblOverdue.Location = new Point(400, 12);
        lblOverdue.Name = "lblOverdue";
        lblOverdue.Size = new Size(78, 21);
        lblOverdue.TabIndex = 2;
        lblOverdue.Text = "Overdue:";
        //
        // lblFines
        //
        lblFines.AutoSize = true;
        lblFines.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblFines.Location = new Point(580, 12);
        lblFines.Name = "lblFines";
        lblFines.Size = new Size(115, 21);
        lblFines.TabIndex = 3;
        lblFines.Text = "Unpaid fines:";
        //
        // txtReport
        //
        txtReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        txtReport.Font = new Font("Consolas", 9.75F);
        txtReport.Location = new Point(12, 85);
        txtReport.Multiline = true;
        txtReport.Name = "txtReport";
        txtReport.ReadOnly = true;
        txtReport.ScrollBars = ScrollBars.Both;
        txtReport.Size = new Size(852, 386);
        txtReport.TabIndex = 5;
        txtReport.WordWrap = false;
        //
        // btnResetData
        //
        btnResetData.Location = new Point(12, 45);
        btnResetData.Name = "btnResetData";
        btnResetData.Size = new Size(180, 30);
        btnResetData.TabIndex = 4;
        btnResetData.Text = "Reset to Demo Data";
        btnResetData.UseVisualStyleBackColor = true;
        btnResetData.Click += btnResetData_Click;
        //
        // tabSearch
        //
        tabSearch.Controls.Add(lblSearch);
        tabSearch.Controls.Add(txtSearch);
        tabSearch.Controls.Add(btnAddItem);
        tabSearch.Controls.Add(btnItemReport);
        tabSearch.Controls.Add(dgvItems);
        tabSearch.Location = new Point(4, 24);
        tabSearch.Name = "tabSearch";
        tabSearch.Padding = new Padding(3);
        tabSearch.Size = new Size(876, 483);
        tabSearch.TabIndex = 1;
        tabSearch.Text = "Search Items";
        tabSearch.UseVisualStyleBackColor = true;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(12, 15);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(140, 15);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Search by title, ID or type:";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(170, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(400, 23);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // btnAddItem
        //
        btnAddItem.Location = new Point(590, 10);
        btnAddItem.Name = "btnAddItem";
        btnAddItem.Size = new Size(130, 27);
        btnAddItem.TabIndex = 2;
        btnAddItem.Text = "Add Item...";
        btnAddItem.UseVisualStyleBackColor = true;
        btnAddItem.Click += btnAddItem_Click;
        //
        // btnItemReport
        //
        btnItemReport.Location = new Point(730, 10);
        btnItemReport.Name = "btnItemReport";
        btnItemReport.Size = new Size(134, 27);
        btnItemReport.TabIndex = 3;
        btnItemReport.Text = "View Report";
        btnItemReport.UseVisualStyleBackColor = true;
        btnItemReport.Click += btnItemReport_Click;
        //
        // dgvItems
        //
        dgvItems.AllowUserToAddRows = false;
        dgvItems.AllowUserToDeleteRows = false;
        dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvItems.Location = new Point(12, 45);
        dgvItems.MultiSelect = false;
        dgvItems.Name = "dgvItems";
        dgvItems.ReadOnly = true;
        dgvItems.RowHeadersVisible = false;
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvItems.Size = new Size(852, 426);
        dgvItems.TabIndex = 4;
        dgvItems.CellFormatting += dgvItems_CellFormatting;
        //
        // tabLoans
        //
        tabLoans.Controls.Add(lblItem);
        tabLoans.Controls.Add(cboItem);
        tabLoans.Controls.Add(lblMember);
        tabLoans.Controls.Add(cboMember);
        tabLoans.Controls.Add(lblBorrow);
        tabLoans.Controls.Add(dtpBorrow);
        tabLoans.Controls.Add(btnCheckOut);
        tabLoans.Controls.Add(lblReturn);
        tabLoans.Controls.Add(dtpReturn);
        tabLoans.Controls.Add(btnCheckIn);
        tabLoans.Controls.Add(lblResult);
        tabLoans.Location = new Point(4, 24);
        tabLoans.Name = "tabLoans";
        tabLoans.Padding = new Padding(3);
        tabLoans.Size = new Size(876, 483);
        tabLoans.TabIndex = 2;
        tabLoans.Text = "Check Out / In";
        tabLoans.UseVisualStyleBackColor = true;
        //
        // lblItem
        //
        lblItem.AutoSize = true;
        lblItem.Location = new Point(12, 18);
        lblItem.Name = "lblItem";
        lblItem.Size = new Size(34, 15);
        lblItem.TabIndex = 0;
        lblItem.Text = "Item:";
        //
        // cboItem
        //
        cboItem.DropDownStyle = ComboBoxStyle.DropDownList;
        cboItem.Location = new Point(110, 15);
        cboItem.Name = "cboItem";
        cboItem.Size = new Size(500, 23);
        cboItem.TabIndex = 1;
        //
        // lblMember
        //
        lblMember.AutoSize = true;
        lblMember.Location = new Point(12, 53);
        lblMember.Name = "lblMember";
        lblMember.Size = new Size(55, 15);
        lblMember.TabIndex = 2;
        lblMember.Text = "Member:";
        //
        // cboMember
        //
        cboMember.DropDownStyle = ComboBoxStyle.DropDownList;
        cboMember.Location = new Point(110, 50);
        cboMember.Name = "cboMember";
        cboMember.Size = new Size(300, 23);
        cboMember.TabIndex = 3;
        //
        // lblBorrow
        //
        lblBorrow.AutoSize = true;
        lblBorrow.Location = new Point(12, 92);
        lblBorrow.Name = "lblBorrow";
        lblBorrow.Size = new Size(77, 15);
        lblBorrow.TabIndex = 4;
        lblBorrow.Text = "Borrow date:";
        //
        // dtpBorrow
        //
        dtpBorrow.Format = DateTimePickerFormat.Short;
        dtpBorrow.Location = new Point(110, 89);
        dtpBorrow.Name = "dtpBorrow";
        dtpBorrow.Size = new Size(150, 23);
        dtpBorrow.TabIndex = 5;
        //
        // btnCheckOut
        //
        btnCheckOut.Location = new Point(270, 85);
        btnCheckOut.Name = "btnCheckOut";
        btnCheckOut.Size = new Size(150, 30);
        btnCheckOut.TabIndex = 6;
        btnCheckOut.Text = "Check Out";
        btnCheckOut.UseVisualStyleBackColor = true;
        btnCheckOut.Click += btnCheckOut_Click;
        //
        // lblReturn
        //
        lblReturn.AutoSize = true;
        lblReturn.Location = new Point(12, 142);
        lblReturn.Name = "lblReturn";
        lblReturn.Size = new Size(74, 15);
        lblReturn.TabIndex = 7;
        lblReturn.Text = "Return date:";
        //
        // dtpReturn
        //
        dtpReturn.Format = DateTimePickerFormat.Short;
        dtpReturn.Location = new Point(110, 139);
        dtpReturn.Name = "dtpReturn";
        dtpReturn.Size = new Size(150, 23);
        dtpReturn.TabIndex = 8;
        //
        // btnCheckIn
        //
        btnCheckIn.Location = new Point(270, 135);
        btnCheckIn.Name = "btnCheckIn";
        btnCheckIn.Size = new Size(150, 30);
        btnCheckIn.TabIndex = 9;
        btnCheckIn.Text = "Check In";
        btnCheckIn.UseVisualStyleBackColor = true;
        btnCheckIn.Click += btnCheckIn_Click;
        //
        // lblResult
        //
        lblResult.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblResult.Location = new Point(12, 190);
        lblResult.Name = "lblResult";
        lblResult.Size = new Size(840, 80);
        lblResult.TabIndex = 10;
        //
        // tabMembers
        //
        tabMembers.Controls.Add(dgvMembers);
        tabMembers.Controls.Add(lblMemberId);
        tabMembers.Controls.Add(txtMemberId);
        tabMembers.Controls.Add(lblMemberName);
        tabMembers.Controls.Add(txtMemberName);
        tabMembers.Controls.Add(btnAddMember);
        tabMembers.Controls.Add(btnRemoveMember);
        tabMembers.Controls.Add(lblPay);
        tabMembers.Controls.Add(nudPayAmount);
        tabMembers.Controls.Add(btnPayFine);
        tabMembers.Controls.Add(btnMemberReport);
        tabMembers.Location = new Point(4, 24);
        tabMembers.Name = "tabMembers";
        tabMembers.Padding = new Padding(3);
        tabMembers.Size = new Size(876, 483);
        tabMembers.TabIndex = 3;
        tabMembers.Text = "Members (Admin)";
        tabMembers.UseVisualStyleBackColor = true;
        //
        // dgvMembers
        //
        dgvMembers.AllowUserToAddRows = false;
        dgvMembers.AllowUserToDeleteRows = false;
        dgvMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvMembers.Location = new Point(12, 12);
        dgvMembers.MultiSelect = false;
        dgvMembers.Name = "dgvMembers";
        dgvMembers.ReadOnly = true;
        dgvMembers.RowHeadersVisible = false;
        dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvMembers.Size = new Size(560, 459);
        dgvMembers.TabIndex = 0;
        //
        // lblMemberId
        //
        lblMemberId.AutoSize = true;
        lblMemberId.Location = new Point(590, 15);
        lblMemberId.Name = "lblMemberId";
        lblMemberId.Size = new Size(68, 15);
        lblMemberId.TabIndex = 1;
        lblMemberId.Text = "Member ID:";
        //
        // txtMemberId
        //
        txtMemberId.Location = new Point(590, 35);
        txtMemberId.Name = "txtMemberId";
        txtMemberId.Size = new Size(260, 23);
        txtMemberId.TabIndex = 2;
        //
        // lblMemberName
        //
        lblMemberName.AutoSize = true;
        lblMemberName.Location = new Point(590, 70);
        lblMemberName.Name = "lblMemberName";
        lblMemberName.Size = new Size(42, 15);
        lblMemberName.TabIndex = 3;
        lblMemberName.Text = "Name:";
        //
        // txtMemberName
        //
        txtMemberName.Location = new Point(590, 90);
        txtMemberName.Name = "txtMemberName";
        txtMemberName.Size = new Size(260, 23);
        txtMemberName.TabIndex = 4;
        //
        // btnAddMember
        //
        btnAddMember.Location = new Point(590, 125);
        btnAddMember.Name = "btnAddMember";
        btnAddMember.Size = new Size(260, 30);
        btnAddMember.TabIndex = 5;
        btnAddMember.Text = "Add Member";
        btnAddMember.UseVisualStyleBackColor = true;
        btnAddMember.Click += btnAddMember_Click;
        //
        // btnRemoveMember
        //
        btnRemoveMember.Location = new Point(590, 165);
        btnRemoveMember.Name = "btnRemoveMember";
        btnRemoveMember.Size = new Size(260, 30);
        btnRemoveMember.TabIndex = 6;
        btnRemoveMember.Text = "Remove Selected Member";
        btnRemoveMember.UseVisualStyleBackColor = true;
        btnRemoveMember.Click += btnRemoveMember_Click;
        //
        // lblPay
        //
        lblPay.AutoSize = true;
        lblPay.Location = new Point(590, 220);
        lblPay.Name = "lblPay";
        lblPay.Size = new Size(170, 15);
        lblPay.TabIndex = 7;
        lblPay.Text = "Pay fine for selected (VND):";
        //
        // nudPayAmount
        //
        nudPayAmount.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
        nudPayAmount.Location = new Point(590, 240);
        nudPayAmount.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudPayAmount.Name = "nudPayAmount";
        nudPayAmount.Size = new Size(260, 23);
        nudPayAmount.TabIndex = 8;
        nudPayAmount.ThousandsSeparator = true;
        //
        // btnPayFine
        //
        btnPayFine.Location = new Point(590, 275);
        btnPayFine.Name = "btnPayFine";
        btnPayFine.Size = new Size(260, 30);
        btnPayFine.TabIndex = 9;
        btnPayFine.Text = "Pay Fine";
        btnPayFine.UseVisualStyleBackColor = true;
        btnPayFine.Click += btnPayFine_Click;
        //
        // btnMemberReport
        //
        btnMemberReport.Location = new Point(590, 325);
        btnMemberReport.Name = "btnMemberReport";
        btnMemberReport.Size = new Size(260, 30);
        btnMemberReport.TabIndex = 10;
        btnMemberReport.Text = "View Details";
        btnMemberReport.UseVisualStyleBackColor = true;
        btnMemberReport.Click += btnMemberReport_Click;
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 511);
        Controls.Add(tabMain);
        MinimumSize = new Size(900, 550);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Smart Library Management System";
        tabMain.ResumeLayout(false);
        tabDashboard.ResumeLayout(false);
        tabDashboard.PerformLayout();
        tabSearch.ResumeLayout(false);
        tabSearch.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
        tabLoans.ResumeLayout(false);
        tabLoans.PerformLayout();
        tabMembers.ResumeLayout(false);
        tabMembers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPayAmount).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabMain;
    private TabPage tabDashboard;
    private Label lblTotal;
    private Label lblBorrowed;
    private Label lblOverdue;
    private Label lblFines;
    private TextBox txtReport;
    private Button btnResetData;
    private TabPage tabSearch;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnAddItem;
    private Button btnItemReport;
    private DataGridView dgvItems;
    private TabPage tabLoans;
    private Label lblItem;
    private ComboBox cboItem;
    private Label lblMember;
    private ComboBox cboMember;
    private Label lblBorrow;
    private DateTimePicker dtpBorrow;
    private Button btnCheckOut;
    private Label lblReturn;
    private DateTimePicker dtpReturn;
    private Button btnCheckIn;
    private Label lblResult;
    private TabPage tabMembers;
    private DataGridView dgvMembers;
    private Label lblMemberId;
    private TextBox txtMemberId;
    private Label lblMemberName;
    private TextBox txtMemberName;
    private Button btnAddMember;
    private Button btnRemoveMember;
    private Label lblPay;
    private NumericUpDown nudPayAmount;
    private Button btnPayFine;
    private Button btnMemberReport;
}
