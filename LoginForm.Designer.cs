namespace SmartLibrary;

partial class LoginForm
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
        lblHeader = new Label();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblError = new Label();
        btnLogin = new Button();
        btnCancel = new Button();
        SuspendLayout();
        //
        // lblHeader
        //
        lblHeader.AutoSize = true;
        lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblHeader.Location = new Point(12, 12);
        lblHeader.Name = "lblHeader";
        lblHeader.Size = new Size(213, 25);
        lblHeader.TabIndex = 0;
        lblHeader.Text = "Smart Library - Sign In";
        //
        // lblUsername
        //
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(12, 58);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(50, 15);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "Staff ID:";
        //
        // txtUsername
        //
        txtUsername.Location = new Point(100, 55);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(240, 23);
        txtUsername.TabIndex = 2;
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(12, 93);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(60, 15);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Password:";
        //
        // txtPassword
        //
        txtPassword.Location = new Point(100, 90);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(240, 23);
        txtPassword.TabIndex = 4;
        txtPassword.UseSystemPasswordChar = true;
        //
        // lblError
        //
        lblError.ForeColor = Color.DarkRed;
        lblError.Location = new Point(12, 122);
        lblError.Name = "lblError";
        lblError.Size = new Size(328, 20);
        lblError.TabIndex = 5;
        //
        // btnLogin
        //
        btnLogin.Location = new Point(154, 148);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(90, 30);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Sign In";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        //
        // btnCancel
        //
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(250, 148);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(90, 30);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Exit";
        btnCancel.UseVisualStyleBackColor = true;
        //
        // LoginForm
        //
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(354, 192);
        Controls.Add(lblHeader);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(lblError);
        Controls.Add(btnLogin);
        Controls.Add(btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sign In";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblHeader;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblError;
    private Button btnLogin;
    private Button btnCancel;
}
