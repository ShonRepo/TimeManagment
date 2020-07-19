using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TimeManagment
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {

        TimeManagmetEntities context = new TimeManagmetEntities();

        public Admin()
        {
            InitializeComponent();
            avatar.Source = EmployeeManagment.ByteToImage(Authorization.User.avatar);
            UserList.ItemsSource = context.user.ToList();
        }

        private void AddNew(object sender, RoutedEventArgs e)
        {
            if (new AddOrUpdateUser().ShowDialog().Value)
            {
                UserList.ItemsSource = context.user.ToList();
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem is user user)
            {
                if (new AddOrUpdateUser(user).ShowDialog().Value)
                {
                    UserList.ItemsSource = context.user.ToList();
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя");
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
