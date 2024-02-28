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

namespace bistro.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddProduce.xaml
    /// </summary>
    public partial class PageAddProduce : Page
    {
        public PageAddProduce()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageProduce());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                important.Product productObj = new important.Product()
                {
                    Name = txbName.Text,
                    Calories = Convert.ToDecimal(txbCalories.Text),
                    Weight = Convert.ToInt16(txbWeight.Text),
                    Price = Convert.ToInt32(txbPrice.Text)
                };
                important.DBHelper.entObj.Product.Add(productObj);
                important.DBHelper.entObj.SaveChanges();
                MessageBox.Show(
                    "Продукт " + productObj.Name + " добавлено",
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
    }
}
