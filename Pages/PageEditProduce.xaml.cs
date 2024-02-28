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
    /// Логика взаимодействия для PageEditProduce.xaml
    /// </summary>
    public partial class PageEditProduce : Page
    {
        private Product p;
        public PageEditProduce(object item)
        {
            InitializeComponent();
            DataContext = item;
            var id = TypeDescriptor.GetProperties(DataContext)["Id"].GetValue(DataContext);
            p = DBHelper.entObj.Product.FirstOrDefault(x => x.Id == (int)id);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageProduce());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            p.Name = txbName.Text;
            p.Calories = Convert.ToDecimal(txbCalories.Text);
            p.Weight = Convert.ToInt16(txbWeight.Text);
            p.Price = Convert.ToInt32(txbPrice.Text);
            DBHelper.entObj.SaveChanges();
        }
    }
}
