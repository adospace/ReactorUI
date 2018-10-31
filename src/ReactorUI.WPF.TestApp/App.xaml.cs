using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReactorUI.WPF.TestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ReactorApplication.Initialize();

            var mainWindow = new MainWindowComponent();

            mainWindow.Run();

            mainWindow.Container.Show();

            base.OnStartup(e);
        }
    }
}
