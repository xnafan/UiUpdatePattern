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
            Animation = new string[] { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" } //snake

            //ALTERNATIVE ANIMATION STYLES
            //Animation = new string[] { "◴", "◷", "◶", "◵" }   //clock
            //Animation = new string[] { "▖", "▘", "▝", "▗" }   //square

        };

        btnGetCustomers.Click += async (_,_) => await GetCustomersAsync();
    } 
    #endregion

    private async Task GetCustomersAsync()
    {
        try
        {
            btnGetCustomers.Enabled = false;                // 1) disable update buton
            btnGetCustomers.Text = "Retrieving data...";    // 2) display busy message
            await GetAndLoadData();                         // 3) perform update in try-catch
        }
        catch (Exception ex)
        {
            // 4) in the catch, be ready to show an error message
            MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // 5) In the finally 
            btnGetCustomers.Enabled = true; // re-enable the update button 
            btnGetCustomers.Text = "&Get Customers";    //remove the busy indicator
        }
    }

    private async Task GetAndLoadData()
    {
        lstCustomers.Items.Clear();
        var customers = await Task.Run(() => _customerDAO.GetAll().ToList());
        customers.ForEach(customer => lstCustomers.Items.Add(customer));
    }
}