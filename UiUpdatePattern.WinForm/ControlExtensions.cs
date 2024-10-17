namespace UiUpdatePattern.WinForm;
public static class ControlExtensions
{
    public static void InvokeIfRequired(this Control control, Action<Control> action)  
    {
        if(control.InvokeRequired) control.Invoke(action, control);
        else action(control); 
    }
}