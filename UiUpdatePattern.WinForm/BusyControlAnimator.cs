namespace UiUpdatePattern.WinForm;

/// <summary>
/// Helper class for animating text on controls, while the application is busy.
/// </summary>
public class BusyControlAnimator
{
    #region Variables and properties
    private bool _running;
    private Control _control;
    private string _controlText;
    private string _busyText;
    private int index = 0;
    private Thread thread;
    private int _animationIntervalInMs;

    /// <summary>
    /// The animation characters to use. Default is a rotating circle, using the unicode characters "◐", "◓", "◑", "◒".
    /// </summary>
    public string[] Animation { get; set; } = { "◐", "◓", "◑", "◒" };
    #endregion

    #region Constructor

    /// <summary>
    /// Instantiates an object, which animates the text of a control, while the application is busy.
    /// </summary>
    /// <param name="control">The control to add textual busy indication to, when SetBusy() is called</param>
    /// <param name="busyText">The text to show on the control, while it is busy. Default is "Working on it"</param>
    /// <param name="animationIntervalInMs">The speed of the animation, defined by the interval between text updates. Default is 150 milliseconds</param>
    public BusyControlAnimator(Control control, string busyText = "Working on it", int animationIntervalInMs = 150)
    {
        _control = control;
        _controlText = _control.Text;
        _busyText = busyText;
        _animationIntervalInMs = animationIntervalInMs;
    }
    #endregion
    
    #region Busy/Idle methods
    public void SetBusy()
    {
        if (_running) return; // Prevent starting multiple threads
        _running = true;
        _control.InvokeIfRequired(() => { _control.Text = _busyText; _control.Enabled = false; });
        thread = new Thread(() => InternalAnimate());
        thread.IsBackground = true; // Ensure the thread exits when the application closes
        thread.Start();
    }

    public void SetIdle()
    {
        _running = false;
        _control.InvokeIfRequired(() => { _control.Text = _controlText; _control.Enabled = true; });
    }

    private void InternalAnimate()
    {
        while (_running)
        {
            index = (index + 1) % Animation.Length;
            _control.InvokeIfRequired(() => _control.Text = Animation[index] + "  " + _busyText + "  " + Animation[index]);
            Thread.Sleep(_animationIntervalInMs);
        }
    } 
    #endregion
}