using FoodMaintenance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoodMaintenance.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public static readonly DependencyProperty TotalPriceProperty =
            DependencyProperty.Register("TotalPrice", typeof(string), typeof(DashboardView), new PropertyMetadata("Total Price: 0"));

        public string TotalPrice
        {
            get { return (string)GetValue(TotalPriceProperty); }
            set { SetValue(TotalPriceProperty, $"Total Price: {value} $"); }
        }
        public DashboardView()
        {
            InitializeComponent();
        }
        private decimal totalPrice = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string additionalParameter = button.Tag as string;
                var dto = button.DataContext as ProductDTO;
                totalPrice += dto.Price ?? 0;
                TotalPrice = totalPrice.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            totalPrice = 0;
            TotalPrice = totalPrice.ToString();
        }
    }
}
