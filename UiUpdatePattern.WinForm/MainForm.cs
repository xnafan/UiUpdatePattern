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
        _busyIndicator = new BusyControlAnimator(btnGetCustomers, "Retrieving data...")
        {
            Animation =
        //new string[]  { "◐", "◓", "◑", "◒" }
        //new string[] { "◴", "◷", "◶", "◵" }
        //new string[] { "▖", "▘", "▝", "▗" }
        new string[] { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" }
        };
        //};
        }
    private async void BtnGetCustomers_Click(object sender, EventArgs e) => await GetCustomersAsync();

    private async Task GetCustomersAsync()
    {
        try
        {
            //btnGetCustomers.Enabled = false;
            _busyIndicator.SetBusy();
            await GetAndLoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            //btnGetCustomers.Enabled = true;
            _busyIndicator.SetIdle();
        }
    }

    private async Task GetAndLoadData()
    {
        lstCustomers.Items.Clear();
        var customers = await Task.Run(() => _customerDAO.GetAll().ToList());
        customers.ForEach(customer => lstCustomers.Items.Add(customer));
    }
}
