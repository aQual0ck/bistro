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
    /// Логика взаимодействия для PageEditDish.xaml
    /// </summary>
    public partial class PageEditDish : Page
    {
        private Dish d;
        public PageEditDish(object item)
        {
            InitializeComponent();
            DataContext = item;
            var id = TypeDescriptor.GetProperties(DataContext)["Id"].GetValue(DataContext);
            d = DBHelper.entObj.Dish.FirstOrDefault(x => x.Id == (int)id);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            d.Name = txbName.Text;
            d.Type = txbType.Text;
            d.Output = Convert.ToInt32(txbOutput.Text);
            d.ImageSource = txbImage.Text;
            DBHelper.entObj.SaveChanges();
        }
    }
}
