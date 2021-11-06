/// <summary>
/// Search anything from anywhere. Force the Current document options to be unselected.
// </summary>
public class EditGoToAll : VisualCommanderExt.ICommand
{
    public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    {
        System.IServiceProvider serviceProvider = package as System.IServiceProvider;
        SetSearchCurrentDocument(serviceProvider, false);
        DTE.ExecuteCommand("Edit.GoToAll");
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
