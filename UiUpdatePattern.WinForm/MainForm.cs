using UiUpdatePattern.WinForm.DAL;
namespace UiUpdatePattern.WinForm;
public partial class MainForm : Form
{
    #region variables and constructor
    private ICustomerDAO _customerDAO;
    private BusyControlAnimator _busyIndicator;
    public MainForm(ICustomerDAO customerDAO)
    {
        InitializeComponent();
        _customerDAO = customerDAO;
        _busyIndicator = new BusyControlAnimator(btnGetCustomers, "Retrieving data...")
        {
            Animation = new string[] { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" }

            //ALTERNATIVE ANIMATION STYLES
            //Animation = new string[]  { "◐", "◓", "◑", "◒" }
            //Animation = new string[] { "◴", "◷", "◶", "◵" }
            //Animation = new string[] { "▖", "▘", "▝", "▗" }

        };

        btnGetCustomers.Click += async (_,_) => await GetCustomersAsync();
    } 
    #endregion

    private async Task GetCustomersAsync()
    {
        try
        {
            _busyIndicator.SetBusy();
            //simpler: btnGetCustomers.Enabled = false;
            await GetAndLoadData();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _busyIndicator.SetIdle();
            //simpler: btnGetCustomers.Enabled = true;
        }
    }

    private async Task GetAndLoadData()
    {
        lstCustomers.Items.Clear();
        var customers = await Task.Run(() => _customerDAO.GetAll().ToList());
        customers.ForEach(customer => lstCustomers.Items.Add(customer));
    }
}