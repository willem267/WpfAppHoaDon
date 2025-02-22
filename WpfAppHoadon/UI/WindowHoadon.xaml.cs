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
        public static RoutedUICommand lenhChon = new RoutedUICommand();
        public static RoutedUICommand lenhLapHD = new RoutedUICommand();
        private CHoadon hd = new CHoadon();
        public WindowHoadon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hoadonContext db = new hoadonContext();
            dgHoadon.ItemsSource = db.Hoadons.ToList();
            cmbMahang.ItemsSource = db.Hanghoas.ToList();
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


        private void chon_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void chon_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            CChitiethoadon ct = gridCTHD.DataContext as CChitiethoadon;
            CChitiethoadon x = new CChitiethoadon
            {
                
                Mahang = ct.Mahang,
                Soluong = ct.Soluong
            };
            hoadonContext db = new hoadonContext();

            x.MahangNavigation = db.Hanghoas.Find(x.Mahang);
            x.Dongia = x.MahangNavigation.Dongia;
            hd.Chitiethoadons.Add(x);
            //dgChitiet.ItemsSource = hd.Chitiethoadons.ToList();
            stackHoaDon.DataContext = CHoadon.saochep(hd);
        }

        private void lap_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void lap_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CHoadon x = stackHoaDon.DataContext as CHoadon;
            hoadonContext db = new hoadonContext();
            Hoadon c = CHoadon.chuyendoi(x);
            foreach(CChitiethoadon ct in x.Chitiethoadons)
            {
                ct.Sohd = x.Sohd;

            }
            db.Hoadons.Add(c);
            db.SaveChanges();
            dgHoadon.ItemsSource = db.Hoadons.ToList();
            hd = new CHoadon();
            stackHoaDon.DataContext = hd;


        }
    }
}
