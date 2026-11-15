namespace SmartLibrary;

partial class AddItemForm
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
        lblType = new Label();
        cboType = new ComboBox();
        lblId = new Label();
        txtId = new TextBox();
        lblTitle = new Label();
        txtTitle = new TextBox();
        btnOk = new Button();
        btnCancel = new Button();
        SuspendLayout();
        //
        // lblType
        //
        lblType.AutoSize = true;
        lblType.Location = new Point(12, 18);
        lblType.Name = "lblType";
        lblType.Size = new Size(34, 15);
        lblType.TabIndex = 0;
        lblType.Text = "Type:";
        //
        // cboType
        //
        cboType.DropDownStyle = ComboBoxStyle.DropDownList;
        cboType.Location = new Point(80, 15);
        cboType.Name = "cboType";
        cboType.Size = new Size(280, 23);
        cboType.TabIndex = 1;
        //
        // lblId
        //
        lblId.AutoSize = true;
        lblId.Location = new Point(12, 53);
        lblId.Name = "lblId";
        lblId.Size = new Size(21, 15);
        lblId.TabIndex = 2;
        lblId.Text = "ID:";
        //
        // txtId
        //
        txtId.Location = new Point(80, 50);
        txtId.Name = "txtId";
        txtId.Size = new Size(280, 23);
        txtId.TabIndex = 3;
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Location = new Point(12, 88);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(32, 15);
        lblTitle.TabIndex = 4;
        lblTitle.Text = "Title:";
        //
        // txtTitle
        //
        txtTitle.Location = new Point(80, 85);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new Size(280, 23);
        txtTitle.TabIndex = 5;
        //
        // btnOk
        //
        btnOk.Location = new Point(174, 125);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(90, 30);
        btnOk.TabIndex = 6;
        btnOk.Text = "Add";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        //
        // btnCancel
        //
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(270, 125);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 30);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        //
        // AddItemForm
        //
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(374, 170);
        Controls.Add(lblType);
        Controls.Add(cboType);
        Controls.Add(lblId);
        Controls.Add(txtId);
        Controls.Add(lblTitle);
        Controls.Add(txtTitle);
        Controls.Add(btnOk);
        Controls.Add(btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AddItemForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Add Library Item";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblType;
    private ComboBox cboType;
    private Label lblId;
    private TextBox txtId;
    private Label lblTitle;
    private TextBox txtTitle;
    private Button btnOk;
    private Button btnCancel;
}
