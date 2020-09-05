/// <summary>
/// Search recent files.
/// </summary>
public class EditGoToRecentFile : VisualCommanderExt.ICommand
{
    public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    {
        serviceProvider = package as System.IServiceProvider;
        SetSearchCurrentDocument(false);
        DTE.ExecuteCommand("Edit.GoToRecentFile");
    }

    private void SetSearchCurrentDocument(bool value)
    {
        System.Type t = serviceProvider.GetService(typeof(SVsNavigateToService)).
            GetType().Assembly.GetType("Microsoft.VisualStudio.PlatformUI.NavigateToSettings");
        object o = t.GetProperty("Instance",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).
            GetValue(null);
        t.GetProperty("SearchCurrentDocument",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).
            SetValue(o, value);
    }

    private System.IServiceProvider serviceProvider;
}

[System.Runtime.InteropServices.Guid("65C44EF9-16F8-4F36-BD73-F10335EC452E")]
public interface SVsNavigateToService
{
}
