using Demo_samoshi.BD_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
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
using static System.Net.Mime.MediaTypeNames;

namespace Demo_samoshi.Page_
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            var BDB = new BD_.DemoSaEntities();

            LVmaterial.ItemsSource = BDB.Material.ToList();
            LVmaterial.SelectedIndex = 0;
            AllPage.Text = LVmaterial.Items.Count.ToString();
            CB_search.ItemsSource = BDB.MaterialType.ToList();
        }




        private void CB_search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var BDB = new BD_.DemoSaEntities();
                var selected_type = CB_search.SelectedItem as BD_.MaterialType;  // получение выбранной позиции из комбобокса и преобразование в нужный тип
            if (selected_type != null)
            {
                LVmaterial.ItemsSource = BDB.Material.Where(i => i.MaterialTypeID == selected_type.ID).ToList();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var BDB = new BD_.DemoSaEntities();
            var search = BDB.Material.ToList();
            search = search.Where(i => i.Title.Contains(tb_search.Text)).ToList();
            LVmaterial.ItemsSource = search.OrderBy(p => p.Title).ToList().Take(15);
            //if (tb_search.Text.Trim().Length == 0)
            //{
            //    LVmaterial.ItemsSource = new BD_.DemoSaEntities().Material.Where(i => i.Title.Contains(tb_search.Text.Trim())).ToList();
            //}
            //else
            //{
            //    LVmaterial.ItemsSource = new BD_.DemoSaEntities().Material.ToList();
            //}
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            Win_.Edit_window ew = new Win_.Edit_window();
            ew.ShowDialog();
        }

        private void Btl_del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BD_.DemoSaEntities dse = new BD_.DemoSaEntities();
                var BD = LVmaterial.SelectedItem as BD_.Material;
                var Var_del = dse.Material.FirstOrDefault(i => i.ID == BD.ID);
                dse.Material.Remove(Var_del);
                dse.SaveChanges();
                LVmaterial.ItemsSource = dse.Material.ToList();
                LVmaterial.SelectedIndex = 0;
            }
            catch
            {
                MessageBox.Show("Выберите данный элемент!");
            }

        }

        private void Btn_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ID = LVmaterial.SelectedItem as BD_.Material;
                Edit_class.ID = ID.ID;
                Win_.Add_window ad = new Win_.Add_window();
                ad.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CB_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BD_.DemoSaEntities dse = new BD_.DemoSaEntities();
            switch (CB_list.Text)
            {

                case "10":
                    var Var_del = dse.Material.Where(i => i.ID < 121);
                    LVmaterial.ItemsSource = Var_del.ToList();
                    return;
                case "50":
                    //LVmaterial.Items[50] = new BD_.DemoSaEntities().Material.ToList();
                    return;
                case "200":
                    //LVmaterial.Items[200] = new BD_.DemoSaEntities().Material.ToList();
                    return;
                case "Все":
                    //LVmaterial.ItemsSource = new BD_.DemoSaEntities().Material.ToList();
                    return;

            }
        }

        private void Page_a_Click(object sender, RoutedEventArgs e)
        {
            BD_.DemoSaEntities BDB = new DemoSaEntities();
            int scroll = Convert.ToInt32(nPage.Text);
            if (Convert.ToInt32(nPage.Text) > 15)
            {
                scroll -= 15;
                nPage.Text = scroll.ToString();
                int sl = scroll - 15;
                LVmaterial.ItemsSource = BDB.Material.ToList().Take(scroll).Skip(sl);
            }
            else
            {
                scroll = 15;
                nPage.Text = scroll.ToString();
                LVmaterial.ItemsSource = BDB.Material.ToList().Take(scroll);
                MessageBox.Show("Last page");
            }
        }

        private void Page_b_Click(object sender, RoutedEventArgs e)
        {
            BD_.DemoSaEntities BDB = new DemoSaEntities();
            int scroll = Convert.ToInt32(nPage.Text);
            if (scroll < Convert.ToInt32(AllPage.Text))
            {
                scroll += 15;
                nPage.Text = scroll.ToString();
                int sl = scroll - 15;
                LVmaterial.ItemsSource = BDB.Material.ToList().Take(scroll).Skip(sl);
            }
            else
            {
                scroll = Convert.ToInt32(AllPage.Text);
                nPage.Text = scroll.ToString();
                int sl = scroll - 15;
                LVmaterial.ItemsSource = BDB.Material.ToList().Take(scroll).Skip(sl);
                MessageBox.Show("Last page");
            }
        }

        
        

        private void AllPage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //A();
        }

   
    }
}

