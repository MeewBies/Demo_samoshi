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
    /// Логика взаимодействия для Reg_window.xaml
    /// </summary>
    public partial class Reg_window : Window
    {
        public Reg_window()
        {
            InitializeComponent();
            MFrame.Navigate(new Page_.MainPage());
        }

        
    }
}
