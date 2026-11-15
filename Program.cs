using System.Text.Json;

namespace SmartLibrary;

internal static class Program
{
    private static readonly string DataPath = Path.Combine(AppContext.BaseDirectory, "library-data.json");

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        var library = LoadLibrary();

        using var login = new LoginForm(library);
        if (login.ShowDialog() != DialogResult.OK || login.User is not Staff user) return;

        Application.Run(new MainForm(library, user, DataPath));
    }

    private static Library LoadLibrary()
    {
        if (!File.Exists(DataPath)) return Library.CreateDemo();
        try
        {
            return LibraryStorage.Load(DataPath);
        }
        catch (Exception ex) when (ex is JsonException or InvalidOperationException or ArgumentException or IOException)
        {
            // Keep the damaged file for inspection instead of overwriting it.
            File.Move(DataPath, DataPath + ".bad", overwrite: true);
            MessageBox.Show($"The data file could not be read ({ex.Message}).\nIt was renamed to library-data.json.bad and sample data was loaded.",
                "Smart Library", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return Library.CreateDemo();
        }
    }
}
