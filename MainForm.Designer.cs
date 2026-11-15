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
        tabSearch = new TabPage();
        lblSearch = new Label();
        txtSearch = new TextBox();
        dgvItems = new DataGridView();
        tabLoans = new TabPage();
        lblItem = new Label();
        cboItem = new ComboBox();
        lblMember = new Label();
        cboMember = new ComboBox();
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
        tabMain.SuspendLayout();
        tabSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
        tabLoans.SuspendLayout();
        tabMembers.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
        SuspendLayout();
        //
        // tabMain
        //
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
        // tabSearch
        //
        tabSearch.Controls.Add(lblSearch);
        tabSearch.Controls.Add(txtSearch);
        tabSearch.Controls.Add(dgvItems);
        tabSearch.Location = new Point(4, 24);
        tabSearch.Name = "tabSearch";
        tabSearch.Padding = new Padding(3);
        tabSearch.Size = new Size(876, 483);
        tabSearch.TabIndex = 0;
        tabSearch.Text = "Search Items";
        tabSearch.UseVisualStyleBackColor = true;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(12, 15);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(201, 15);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "Search by title, ID or type:";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(220, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(400, 23);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // dgvItems
        //
        dgvItems.AllowUserToAddRows = false;
        dgvItems.AllowUserToDeleteRows = false;
        dgvItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvItems.Location = new Point(12, 45);
        dgvItems.Name = "dgvItems";
        dgvItems.ReadOnly = true;
        dgvItems.RowHeadersVisible = false;
        dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvItems.Size = new Size(852, 426);
        dgvItems.TabIndex = 2;
        //
        // tabLoans
        //
        tabLoans.Controls.Add(lblItem);
        tabLoans.Controls.Add(cboItem);
        tabLoans.Controls.Add(lblMember);
        tabLoans.Controls.Add(cboMember);
        tabLoans.Controls.Add(btnCheckOut);
        tabLoans.Controls.Add(lblReturn);
        tabLoans.Controls.Add(dtpReturn);
        tabLoans.Controls.Add(btnCheckIn);
        tabLoans.Controls.Add(lblResult);
        tabLoans.Location = new Point(4, 24);
        tabLoans.Name = "tabLoans";
        tabLoans.Padding = new Padding(3);
        tabLoans.Size = new Size(876, 483);
        tabLoans.TabIndex = 1;
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
        // btnCheckOut
        //
        btnCheckOut.Location = new Point(110, 85);
        btnCheckOut.Name = "btnCheckOut";
        btnCheckOut.Size = new Size(150, 30);
        btnCheckOut.TabIndex = 4;
        btnCheckOut.Text = "Check Out";
        btnCheckOut.UseVisualStyleBackColor = true;
        btnCheckOut.Click += btnCheckOut_Click;
        //
        // lblReturn
        //
        lblReturn.AutoSize = true;
        lblReturn.Location = new Point(12, 143);
        lblReturn.Name = "lblReturn";
        lblReturn.Size = new Size(74, 15);
        lblReturn.TabIndex = 5;
        lblReturn.Text = "Return date:";
        //
        // dtpReturn
        //
        dtpReturn.Format = DateTimePickerFormat.Short;
        dtpReturn.Location = new Point(110, 140);
        dtpReturn.Name = "dtpReturn";
        dtpReturn.Size = new Size(150, 23);
        dtpReturn.TabIndex = 6;
        //
        // btnCheckIn
        //
        btnCheckIn.Location = new Point(110, 175);
        btnCheckIn.Name = "btnCheckIn";
        btnCheckIn.Size = new Size(150, 30);
        btnCheckIn.TabIndex = 7;
        btnCheckIn.Text = "Check In";
        btnCheckIn.UseVisualStyleBackColor = true;
        btnCheckIn.Click += btnCheckIn_Click;
        //
        // lblResult
        //
        lblResult.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblResult.Location = new Point(12, 230);
        lblResult.Name = "lblResult";
        lblResult.Size = new Size(840, 80);
        lblResult.TabIndex = 8;
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
        tabMembers.Location = new Point(4, 24);
        tabMembers.Name = "tabMembers";
        tabMembers.Padding = new Padding(3);
        tabMembers.Size = new Size(876, 483);
        tabMembers.TabIndex = 2;
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
        tabSearch.ResumeLayout(false);
        tabSearch.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
        tabLoans.ResumeLayout(false);
        tabLoans.PerformLayout();
        tabMembers.ResumeLayout(false);
        tabMembers.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabMain;
    private TabPage tabSearch;
    private Label lblSearch;
    private TextBox txtSearch;
    private DataGridView dgvItems;
    private TabPage tabLoans;
    private Label lblItem;
    private ComboBox cboItem;
    private Label lblMember;
    private ComboBox cboMember;
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
}
