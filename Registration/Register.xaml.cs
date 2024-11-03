using Registration.Models;
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
using System.Windows.Shapes;

namespace Registration
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        public bool RegisterUser(string username, string password)
        {
            using (var context = new RegisterContext())
            {
                // Check if an user info have existed in Database
                if (context.UserInfos.Any(u => u.FullName == username))
                {
                    return false; // Signup fail bcs user info existed in DB
                }

                // Add new user
                var newUserInfo = new UserInfo { FullName = username, PassWd = password };
                context.UserInfos.Add(newUserInfo);
                context.SaveChanges();
                return true;
            }
        }

        private void Signup_Btn_Click(object sender, RoutedEventArgs e)
        {
            string username = userNameTxtBox.Text;
            string password = passWdBox.Password;
            string confirm = confimrPassBox.Password;

            // Secure that user fill in all fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Please fill in all fields.");
                userNameTxtBox.Clear();
                passWdBox.Clear();
                confimrPassBox.Clear();
                userNameTxtBox.Focus();
                return;
            }

            // Check password and confirm
            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match. Please refill");
                passWdBox.Clear();
                confimrPassBox.Clear();
                passWdBox.Focus();
                return;
            }

            if (RegisterUser(username, password))
            {
                MessageBox.Show("Signup successfull!");
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different one.");
            }

            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
