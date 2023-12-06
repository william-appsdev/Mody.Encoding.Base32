using System.Configuration;
using System.Data;
using System.Windows;

namespace Mody.Encoding.Base32.WpfApp
{
    public partial class App : Application
    {
        public App()
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow.Show();
        }
    }

}
