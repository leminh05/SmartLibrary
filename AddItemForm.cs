namespace SmartLibrary;

public partial class AddItemForm : Form
{
    public LibraryItem? CreatedItem { get; private set; }

    public AddItemForm()
    {
        InitializeComponent();
        cboType.Items.AddRange(ItemFactory.Types);
        cboType.SelectedIndex = 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            CreatedItem = ItemFactory.Create((string)cboType.SelectedItem!, txtId.Text, txtTitle.Text);
            DialogResult = DialogResult.OK;
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
