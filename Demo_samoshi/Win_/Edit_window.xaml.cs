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
    /// Логика взаимодействия для Edit_window.xaml
    /// </summary>
    public partial class Edit_window : Window
    {
        public Edit_window()
        {
            InitializeComponent();
        }

        private void Btn_Added_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BD_.DemoSaEntities DSE = new BD_.DemoSaEntities();
                var AD = new BD_.Material();
                    AD.Title = tb_title.Text;
                    AD.CountInPack = Convert.ToInt32(tb_Countpack.Text);
                    AD.CountInStock = Convert.ToInt32(tb_Countstack.Text);
                    AD.MinCount = Convert.ToInt32(tb_MinCount.Text);
                    AD.Description = tb_description.Text;
                    AD.Cost = Convert.ToInt32(tb_cost.Text);
                    AD.Image = "/picture.png";
                switch(CB_material.Text)
                {
                    case "Силикон":
                        AD.MaterialTypeID = 5;
                        break;
                    case "Резина":
                        AD.MaterialTypeID = 2;
                        break;
                    case "Краска":
                        AD.MaterialTypeID = 3;
                        break;
                }
                switch(CB_type.Text)
                {
                    case "кг":
                        break;
                    case "м":
                        break;
                    case "л":
                        break;
                }
                AD.Unit = CB_type.Text;
                DSE.Material.Add(AD);
                DSE.SaveChanges();
                MessageBox.Show("Успешно");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
