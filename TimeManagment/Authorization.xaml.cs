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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        TimeManagmetEntities context = new TimeManagmetEntities();

        public static user User { get; set; }

        public Authorization()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LogInSystem(object sender, RoutedEventArgs e)
        {
            var user = context.user.Where(i => i.email == Login.Text &&
            i.password == Pass.Text);
            if(user.Count() >0)
            {
                User = user.FirstOrDefault();
                switch (user.FirstOrDefault().role)
                {
                    case 1:
                        NavigationService.Navigate(new EmployeeManagment());
                        break;
                    case 2:
                        NavigationService.Navigate(new Managers());
                        break;
                    case 3:
                        NavigationService.Navigate(new Admin());
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("введите верные данные");
            }
        }
    }
}
