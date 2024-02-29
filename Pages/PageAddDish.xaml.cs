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
using Microsoft.Win32;

namespace bistro.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddDish.xaml
    /// </summary>
    public partial class PageAddDish : Page
    {
        public PageAddDish()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                important.Dish dishObj = new important.Dish()
                {
                    Name = txbName.Text,
                    Type = txbType.Text,
                    Output = Convert.ToInt32(txbOutput.Text),
                    ImageSource = txbImage.Text
                };
                important.DBHelper.entObj.Dish.Add(dishObj);
                important.DBHelper.entObj.SaveChanges();
                MessageBox.Show(
                    "Блюдо " + dishObj.Name + " добавлено",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Критическая ошибка" + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageAdmin());
        }

        private void btnFolder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".jpg";
            ofd.Filter = "Файлы рисунков | *.jpg";
            ofd.InitialDirectory = @"D:\projects\csharp\bistro\images";
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                txbImage.Text = ofd.FileName;
            }
        }
    }
}
