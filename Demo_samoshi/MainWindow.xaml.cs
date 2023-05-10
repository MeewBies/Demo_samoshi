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

namespace Demo_samoshi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //
                var User = new BD_.DemoSaEntities().Agent.FirstOrDefault(i => i.Title == tb_lg.Text && i.INN == tb_ps.Text);
                if (User != null)
                {
                    MessageBox.Show("Успешно!");
                    Win_.Reg_window mw = new Win_.Reg_window();
                    mw.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильные данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
