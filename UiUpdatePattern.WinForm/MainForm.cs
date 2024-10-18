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
            // 1 and 2 - sets the button to Enabled = false
            // and changes the text to "Retrieving data..."
            _busyIndicator.SetBusy(); 
            await GetAndLoadData();                         // 3) perform update in try-catch
        }
        catch (Exception ex)
        {
            // 4) in the catch, be ready to show an error message
            MessageBox.Show($"An error occurred while loading data: {ex.Message}", 
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        finally
        {
            // 5) In the finally 
            // sets the button back to Enabled and restores the original text
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