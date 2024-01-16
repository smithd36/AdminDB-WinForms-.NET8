using System;
using System.IO;
using System.Windows.Forms;

namespace AdminDB
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Get the application data folder
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Combine the application data folder with your app name and database file name
            string databasePath = Path.Combine(appDataFolder, "AdminDB", "appdata.db");

            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(databasePath));

            // Create an instance of UserDbContext with the full path to the database
            UserDbContext userDbContext = new UserDbContext(databasePath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Pass the UserDbContext instance to the LoginForm constructor
            Application.Run(new LoginForm(userDbContext));
        }
    }
}
