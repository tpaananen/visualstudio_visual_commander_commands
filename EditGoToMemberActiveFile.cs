/// <summary>
/// Search members and types from currently active file.
/// </summary>
public class EditGoToSymbolActiveFile : VisualCommanderExt.ICommand
{
    // Bind to hotkey in the context of Text Editor

    public void Run(EnvDTE80.DTE2 DTE, Microsoft.VisualStudio.Shell.Package package) 
    {
        System.IServiceProvider serviceProvider = package as System.IServiceProvider;
        SetSearchCurrentDocument(serviceProvider, true);
        SyncWithActiveDocument(DTE);
        DTE.ExecuteCommand("Edit.GoToSymbol");
    }

    private void SetSearchCurrentDocument(System.IServiceProvider serviceProvider, bool value)
    {
        System.Type type = serviceProvider.GetService(typeof(SVsNavigateToService)).GetType().Assembly.GetType("Microsoft.VisualStudio.PlatformUI.NavigateToSettings");
        object obj = type
           .GetProperty("Instance", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
           .GetValue(null);
        type.GetProperty("SearchCurrentDocument", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).SetValue(obj, value);
    }
    
    private void SyncWithActiveDocument(EnvDTE80.DTE2 DTE) 
    {
        try 
        {
       	    DTE.ExecuteCommand("SolutionExplorer.SyncWithActiveDocument");
	    }
	    catch (System.Runtime.InteropServices.COMException) {} // catch if no active file
    }
}

[System.Runtime.InteropServices.Guid("65C44EF9-16F8-4F36-BD73-F10335EC452E")]
public interface SVsNavigateToService
{
}
