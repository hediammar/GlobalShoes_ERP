using System.Windows;

namespace WpfAppGlobalShoes
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Run the console tester
            ConsoleTester.Run();

            // You can also start your WPF application here if needed
            // MainWindow mainWindow = new MainWindow();
            // mainWindow.Show();
        }
    }
}
