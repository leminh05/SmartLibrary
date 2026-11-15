namespace SmartLibrary;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
#if DEBUG
        SelfCheck.Run();
#endif
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
