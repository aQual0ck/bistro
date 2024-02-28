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
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace bistro.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(txbLogin.Text))
            {
                txbLogin.Text = "Введите логин";
                txbLogin.Foreground = Brushes.Gray;
                txbLogin.GotFocus += RemoveText_Login;
                txbLogin.LostFocus += AddText;
            }
            if (string.IsNullOrEmpty(psbPassword.Text))
            {
                psbPassword.Text = "Введите пароль";
                psbPassword.Foreground = Brushes.Gray;
                psbPassword.GotFocus += RemoveText_Password;
                psbPassword.LostFocus += AddText;
            }
        }

        private void txbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbLogin.Foreground = Brushes.Black;
        }
        public void RemoveText_Login(object sender, EventArgs e)
        {
            if (txbLogin.Text == "Введите логин")
                txbLogin.Text = "";
        }
        public void RemoveText_Password(object sender, EventArgs e)
        {
            if (psbPassword.Text == "Введите пароль")
                psbPassword.Text = "";
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbLogin.Text))
            {
                txbLogin.Text = "Введите логин";
                txbLogin.Foreground = Brushes.Gray;
            }
            if (string.IsNullOrEmpty(psbPassword.Text))
            {
                psbPassword.Text = "Введите пароль";
                psbPassword.Foreground = Brushes.Gray;
            }
        }

        private void psbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            psbPassword.Foreground = Brushes.Black;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbLogin.Text != "" && txbLogin.Text != "Введите логин" && psbPassword.Text != "" && psbPassword.Text != "Введите пароль") 
                {
                    var userObj = important.DBHelper.entObj.Users.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Text);
                    if (userObj == null)
                    {
                        tbWarning.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        important.FrameApp.frmObj.Navigate(new PageAdmin());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.GoBack();
        }
    }
}
