using UiUpdatePattern.WinForm.DAL;
namespace UiUpdatePattern.WinForm;
public partial class MainForm : Form
{
    private ICustomerDAO _customerDAO;
    private BusyControlAnimator _busyIndicator;
    public MainForm(ICustomerDAO customerDAO)
    {
        InitializeComponent();
        _customerDAO = customerDAO;
        _busyIndicator = new BusyControlAnimator(btnGetCustomers) { Animation =
        new string[]  { "◐", "◓", "◑", "◒" } };
    }
    private async void BtnGetCustomers_Click(object sender, EventArgs e) => await GetCustomersAsync();

    private async Task GetCustomersAsync()
    {
        try
        {
            _busyIndicator.SetBusy();
            lstCustomers.Items.Clear();
            var customers = await Task.Run(() => _customerDAO.GetAll().ToList());
            customers.ForEach(customer => lstCustomers.Items.Add(customer));
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _busyIndicator.SetIdle();
        }
    }

    private void EnableButton() => btnGetCustomers.Enabled = true;
    private void DisableButton() => btnGetCustomers.Enabled = false;
}
