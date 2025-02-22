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
using WpfAppHoadon.Models;
using WpfAppHoadon.MyModels;

namespace WpfAppHoadon.UI
{
    /// <summary>
    /// Interaction logic for WindowHoadon.xaml
    /// </summary>
    public partial class WindowHoadon : Window
    {
        public WindowHoadon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hoadonContext db = new hoadonContext();
            dgHoadon.ItemsSource = db.Hoadons.ToList();
        }

        private void dgHoadon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            Hoadon hd = e.Row.Item as Hoadon;
            hoadonContext db = new hoadonContext();
            hd.Chitiethoadons =db.Chitiethoadons.Where(t => t.Sohd == hd.Sohd).ToList();
            foreach (Chitiethoadon cthd in hd.Chitiethoadons)
            {
                cthd.MahangNavigation = db.Hanghoas.Find(cthd.Mahang);
            }
            FrameworkElement fw =  e.DetailsElement;
            StackPanel sp = fw.FindName("stackHoadon") as StackPanel;
            sp.DataContext=CHoadon.chuyendoi(hd);
        }
    }
}
