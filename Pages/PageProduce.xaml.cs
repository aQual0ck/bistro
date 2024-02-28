using bistro.important;
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
using System.ComponentModel;

namespace bistro.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProduce.xaml
    /// </summary>
    public partial class PageProduce : Page
    {
        private Product p;
        public PageProduce()
        {
            InitializeComponent();

            dgrProduce.ItemsSource = DBHelper.entObj.Product.ToList();
        }

        private void btnDish_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageAdmin());
        }

        private void btnAddProduce_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageAddProduce());
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageGuest());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = dgrProduce.SelectedItem;
            important.FrameApp.frmObj.Navigate(new PageEditProduce(item));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var id = TypeDescriptor.GetProperties(dgrProduce.SelectedItem)["Id"].GetValue(dgrProduce.SelectedItem);
            p = DBHelper.entObj.Product.FirstOrDefault(x => x.Id == (int)id);
            MessageBoxResult result = MessageBox.Show("Вы уверены?");
            if (result == MessageBoxResult.OK)
            {
                DBHelper.entObj.Product.Remove(p);
                DBHelper.entObj.SaveChanges();
                dgrProduce.ItemsSource = important.DBHelper.entObj.Dish.ToList();
            }
        }
    }
}
