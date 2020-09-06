/// <summary>
/// Search members and types from currently active file.
/// </summary>
public class EditGoToSymbolActiveFile : VisualCommanderExt.ICommand
{
    // Bind to hotkey in the context of Text Editor
    // This will throw an error when running from the VCmd editor window but works once you have an open document active

    public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    {
        serviceProvider = package as System.IServiceProvider;
        SetSearchCurrentDocument(true);
        DTE.ExecuteCommand("SolutionExplorer.SyncWithActiveDocument");
        DTE.ExecuteCommand("Edit.GoToSymbol");
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
