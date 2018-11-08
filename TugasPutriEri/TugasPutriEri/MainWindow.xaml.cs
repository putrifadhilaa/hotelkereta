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
using TugasPutriEri.BaseContext;
using TugasPutriEri.Model;

namespace TugasPutriEri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext context = new MyContext();
        District district = new District();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var getcarikota = context.Districts.Where(x => x.IsDelete == false).ToList();
            carikota.ItemsSource = getcarikota;
        }
    }
}
