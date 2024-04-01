using FoodMaintenance.Interfaces;
using FoodMaintenance.Models;
using FoodMaintenance.Services;
using FoodMaintenance.ViewModels;
using System.Windows;

namespace FoodMaintenance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Methods
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new Login_Page.MainWindow();

            MainWindow.Show();

            base.OnStartup(e);
        }
        #endregion
    }
}
