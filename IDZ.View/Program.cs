using IDZ.Persistense.Configuration;
using IDZ.View.Forms;
using Microsoft.Extensions.Configuration;
namespace IDZ.View
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("Default");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Connection string not found in appsettings.json");

            DatabaseConfiguration.Initialize(connectionString);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}