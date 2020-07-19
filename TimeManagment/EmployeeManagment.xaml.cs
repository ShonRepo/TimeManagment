using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for EmployeeManagment.xaml
    /// </summary>
    public partial class EmployeeManagment : Page
    {
        TimeManagmetEntities context = new TimeManagmetEntities();

        private accounting accounting;
        public EmployeeManagment()
        {
            InitializeComponent();
            avatar.Source = ByteToImage(Authorization.User.avatar);
            WorkList.ItemsSource = context.accounting.Where(i => i.user == Authorization.User.id).ToList();

        }

        private void Start(object sender, RoutedEventArgs e)
        {

            accounting = new accounting();
            accounting.status = 1;
            accounting.startWork = DateTime.Now;
            accounting.user = Authorization.User.id;
            accounting.endwork = null;
            Startbt.IsEnabled = false;
            Stopbt.IsEnabled = true;
            info.Content = $"Начал работу {accounting.startWork}";
            context.accounting.AddOrUpdate(accounting);
            context.SaveChanges();
        }

        private void End(object sender, RoutedEventArgs e)
        {
            accounting.endwork = DateTime.Now;
            accounting.status = 2;
            info.Content = $"Вы работали {Convert.ToInt32((accounting.endwork - accounting.startWork).Value.TotalMinutes)} минут";
            context.accounting.AddOrUpdate(accounting);
            Startbt.IsEnabled = true;
            Stopbt.IsEnabled = false;
            context.SaveChanges();
            WorkList.ItemsSource = context.accounting.Where(i => i.user == Authorization.User.id).ToList();
        }

        public static BitmapImage ByteToImage(byte[] array)
        {
            if (array is null)
            {
                return new BitmapImage(new Uri("IGnQtuGWRbQ.jpg", UriKind.Relative));
            }
            using (MemoryStream ms = new MemoryStream(array, 0, array.Length))
            {
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Authorization());
        }
    }
}
