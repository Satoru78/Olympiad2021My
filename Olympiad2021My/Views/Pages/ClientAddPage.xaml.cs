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
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Page
    {
        public Client Client { get; set; }
      
        public List<Gender> Genders { get; set; }
        public ClientAddPage(Client client)
        {
            InitializeComponent();
            Client = client;
            Genders = Data.db.Gender.ToList();       
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Client.ID == 0)
                {
                    Data.db.Client.Add(Client);
                }
               Data.db.SaveChanges();
                MessageBox.Show("Данные сохранены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Произошла ошибка");
            }
        }
    }
}
