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

namespace TimeManagment
{
    /// <summary>
    /// Interaction logic for Managers.xaml
    /// </summary>
    public partial class Managers : Page
    {
        TimeManagmetEntities context = new TimeManagmetEntities();


        public Managers()
        {
            InitializeComponent();
            avatar.Source = EmployeeManagment.ByteToImage(Authorization.User.avatar);
            WorkList.ItemsSource = context.accounting.ToList();

        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            if (Work.IsChecked.Value)
            {
                WorkList.ItemsSource = context.accounting.Where(i =>i.status == 1).ToList();
            }
            else
            {
                WorkList.ItemsSource = context.accounting.ToList();

            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
