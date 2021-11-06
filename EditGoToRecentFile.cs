/// <summary>
/// Search recent files.
/// </summary>
public class EditGoToRecentFile : VisualCommanderExt.ICommand
{
    public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    {
        System.IServiceProvider serviceProvider = package as System.IServiceProvider;
        SetSearchCurrentDocument(serviceProvider, false);
        DTE.ExecuteCommand("Edit.GoToRecentFile");
    }

    private void SetSearchCurrentDocument(System.IServiceProvider serviceProvider, bool value)
    {
        System.Type type = serviceProvider.GetService(typeof(SVsNavigateToService)).GetType().Assembly.GetType("Microsoft.VisualStudio.PlatformUI.NavigateToSettings");
        object obj = type.GetProperty("Instance", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).GetValue(null);
        type.GetProperty("SearchCurrentDocument", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).SetValue(obj, value);
    }
}

[System.Runtime.InteropServices.Guid("65C44EF9-16F8-4F36-BD73-F10335EC452E")]
public interface SVsNavigateToService
{
}
