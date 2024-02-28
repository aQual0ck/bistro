﻿using System;
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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            dgrDishes.ItemsSource = important.DBHelper.entObj.Dish.ToList();

            cmbType.SelectedValuePath = "Type";
            cmbType.DisplayMemberPath = "Type";
            cmbType.ItemsSource = important.DBHelper.entObj.Dish.ToList();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageGuest());
        }
        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SelectedGroup = Convert.ToString(cmbType.SelectedValue);

            dgrDishes.ItemsSource = important.DBHelper.entObj.Dish.Where(x => x.Type == SelectedGroup).ToList();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageProduce());
        }

        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            important.FrameApp.frmObj.Navigate(new PageAddDish());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = dgrDishes.SelectedItem;
            important.FrameApp.frmObj.Navigate(new PageEditDish(item));
        }
    }
}
