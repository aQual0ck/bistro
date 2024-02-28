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
    /// Логика взаимодействия для PageGuest.xaml
    /// </summary>
    public partial class PageGuest : Page
    {
        public PageGuest()
        {
            InitializeComponent();

            dgrDishes.ItemsSource = important.DBHelper.entObj.Dish.ToList();

            cmbType.SelectedValuePath = "Type";
            cmbType.DisplayMemberPath = "Type";
            cmbType.ItemsSource = important.DBHelper.entObj.Dish.GroupBy(x => x.Type).ToList();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageLogin());
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedGroup = Convert.ToString(cmbType.SelectedValue);

            dgrDishes.ItemsSource = important.DBHelper.entObj.Dish.Where(x => x.Type == SelectedGroup).ToList();
        }

        private void dgrDishes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = dgrDishes.SelectedItem;
            var id = dgrDishes.Items.IndexOf(item);
            {
                if (item != null)
                {
                    important.FrameApp.frmObj.Navigate(new PageDescription(item));
                }
            }
        }
    }
}
