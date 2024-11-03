using Registration.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, MouseButtonEventArgs e)
        {
            Register regisWindow = new Register();
            regisWindow.Show();
            this.Close();
        }

        public bool CheckLogin(string username, string password)
        {
            using (var context = new RegisterContext())
            {
                var user = context.UserInfos.FirstOrDefault(u => u.FullName == username && u.PassWd == password);
                return user != null;
            }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string username = userNameTxtBox.Text;
            string password = passWdBox.Password;

            if (CheckLogin(username, password))
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}