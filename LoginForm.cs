namespace SmartLibrary;

public partial class LoginForm : Form
{
    private const int MaxAttempts = 3;
    private readonly Library library;
    private int failedAttempts;

    public Staff? User { get; private set; }

    public LoginForm(Library library)
    {
        InitializeComponent();
        this.library = library;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        User = library.Login(txtUsername.Text, txtPassword.Text);
        if (User != null)
        {
            DialogResult = DialogResult.OK;
            return;
        }

        failedAttempts++;
        txtPassword.Clear();
        if (failedAttempts >= MaxAttempts)
        {
            MessageBox.Show("Too many failed attempts. The application will close.", "Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.Cancel;
            return;
        }
        lblError.Text = $"Wrong ID or password. {MaxAttempts - failedAttempts} attempt(s) left.";
        txtPassword.Focus();
    }
}
