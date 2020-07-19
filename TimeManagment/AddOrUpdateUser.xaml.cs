using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace TimeManagment
{
    /// <summary>
    /// Interaction logic for AddOrUpdateUser.xaml
    /// </summary>
    public partial class AddOrUpdateUser : Window
    {
        TimeManagmetEntities context = new TimeManagmetEntities();

        private user user;

        private byte[] Image;

        public AddOrUpdateUser()
        {
            InitializeComponent();
            user = new user();
            LoadRole();
        }

        public AddOrUpdateUser(user user)
        {
            InitializeComponent();
            this.user = user;
            LoadRole();
            avatar.Source = EmployeeManagment.ByteToImage(user.avatar);
            lastName.Text = user.lastName;
            firstName.Text = user.firstName;
            email.Text = user.email;
            pass.Text = user.password;
            role.SelectedItem = context.role.Find(user.role);

        }

        private void LoadRole()
        {
            role.ItemsSource = context.role.ToList();
        }

        private void AddAvatar(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog().Value)
            {
                Image = File.ReadAllBytes(openFileDialog.FileName);
                avatar.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                user.role = (role.SelectedItem as role).id;
                user.avatar = Image;
                user.firstName = firstName.Text;
                user.lastName = lastName.Text;
                user.email = email.Text;
                user.password = pass.Text;
                context.user.AddOrUpdate(user);
                context.SaveChanges();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
