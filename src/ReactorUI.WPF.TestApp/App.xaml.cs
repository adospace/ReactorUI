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
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //ReactorApplication.Initialize();

            //var mainWindow = new Window();
            //var mainWindowComponent = 
            //    new MainWindowComponent(mainWindow)
            //    .Run();

            WPF.ReactorApplication
                .Create(new MainWindowComponent())
                
                .Run();


            //mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
