using Olympiad2021My.Context;
using Olympiad2021My.Model;
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

namespace Olympiad2021My.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public Service Service { get; set; }
        public Client Client { get; set; }
        public List<Service> Services { get; set; }
        public ServiceListPage(Service service)
        {
            InitializeComponent();
            Service = service;           
            this.DataContext = this;
        }

        private void Sort(string discount = "",string search = "")
        {
            var service = Data.db.Service.ToList();
            if (!string.IsNullOrEmpty(discount) && !string.IsNullOrEmpty(discount))
            {
                if (discount == "от 0% до 5%")
                    service = service.Where(item => 0 <= item.Discount && item.Discount <= 5).ToList();
                if (discount == "от 5% до 15%")
                    service = service.Where(item => 5 <= item.Discount && item.Discount <= 15).ToList();
                if (discount == "от 15% до 30%")
                    service = service.Where(item => 15 <= item.Discount && item.Discount <= 30).ToList();
                if (discount == "от 30% до 70%")
                    service = service.Where(item => 30 <= item.Discount && item.Discount <= 70).ToList();
                if (discount == "от 70% до 100%")
                    service = service.Where(item => 70 <= item.Discount && item.Discount <= 100).ToList();
            }
            ServiceListView.ItemsSource = service;
        }
        private void cmbDiscountsort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort((cmbDiscountsort.SelectedItem as ComboBoxItem).Content.ToString(), cmbDiscountsort.Text);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Services = Data.db.Service.ToList();
            ServiceListView.ItemsSource = Services;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
