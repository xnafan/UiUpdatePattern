namespace UiUpdatePattern.WinForm;
public static class ControlExtensions
{
    /// <summary>
    /// Extension method to use invoke if required
    /// </summary>
    /// <param name="control">The control to use for the InvokeRequired check</param>
    /// <param name="action">The action to perform, in an Invoked context if necessary</param>
    public static void InvokeIfRequired(this Control control, Action action)  
    {
        if(control.InvokeRequired) control.Invoke(action);
        else action(); 
    }
}