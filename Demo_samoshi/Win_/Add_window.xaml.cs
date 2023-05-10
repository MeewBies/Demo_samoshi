using Demo_samoshi.Page_;
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
using System.Windows.Shapes;

namespace Demo_samoshi.Win_
{
    /// <summary>
    /// Логика взаимодействия для Add_window.xaml
    /// </summary>
    public partial class Add_window : Window
    {
        BD_.DemoSaEntities DSE = new BD_.DemoSaEntities();  
        public Add_window()
        {
            InitializeComponent();
            var mat = DSE.Material.FirstOrDefault(i => i.ID == Edit_class.ID);
            tb_name.Text = mat.Title.ToString();
            tb_description.Text = mat.Description.ToString();
            tb_cost.Text = mat.Cost.ToString();
            tb_CountPack.Text = mat.CountInPack.ToString();
            tb_CountStack.Text = mat.CountInStock.ToString();   
            tb_MinCount.Text = mat.MinCount.ToString();  
        }

        private void Btn_Added_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mat = DSE.Material.FirstOrDefault(i => i.ID == Edit_class.ID);
                mat.Title = tb_name.Text;
                mat.Description = tb_description.Text;
                mat.Cost = Convert.ToInt32(tb_cost.Text);
                mat.CountInPack = Convert.ToInt32(tb_CountPack.Text);
                mat.CountInStock = Convert.ToInt32(tb_CountStack.Text);
                mat.MinCount = Convert.ToInt32(tb_MinCount.Text);
                DSE.SaveChanges();
                MessageBox.Show("Успешно!");

            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }
    }
}
