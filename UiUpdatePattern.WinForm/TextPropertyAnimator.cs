namespace UiUpdatePattern.WinForm;
public class BusyControlAnimator
{
    private bool _running;
    Control _control;
    private string _controlText;
    private string _busyText;
    private int index = 0;
    private Thread thread;
    private int _animationIntervalInMs;

    public BusyControlAnimator(Control control, string busyText = "Working on it", int animationIntervalInMs = 150)
    {
        _control = control;
        _controlText = _control.Text;
        _busyText = busyText;
        _animationIntervalInMs = animationIntervalInMs;
    }

    public string[] Animation { get ; set; } = { "◐", "◓", "◑", "◒" };

public void SetBusy()
    {
        if (_running) return; // Prevent starting multiple threads
        _running = true;
        _control.InvokeIfRequired(c => c.Text = _busyText);
        _control.InvokeIfRequired(c => c.Enabled = false);
        thread = new Thread(() => InternalAnimate());
        thread.IsBackground = true; // Ensure the thread exits when the application closes
        thread.Start();
    }

    public void SetIdle()
    {
        _running = false;
        _control.InvokeIfRequired(c => c.Text = _controlText);
        _control.InvokeIfRequired(c => c.Enabled = true);
    }

    private void InternalAnimate()
    {
        while (_running)
        {
            index = (index + 1) % Animation.Length;
            _control.InvokeIfRequired((_) => _control.Text = Animation[index] + "  " +_busyText + "  " + Animation[index]);
            Thread.Sleep(_animationIntervalInMs);
        }
    }
}