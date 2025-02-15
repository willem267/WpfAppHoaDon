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

namespace WpfAppHoadon.UI
{
    /// <summary>
    /// Interaction logic for WindowHanghoa.xaml
    /// </summary>
    public partial class WindowHanghoa : Window
    {
        public static RoutedUICommand lenhThem = new RoutedUICommand();

        public static RoutedUICommand lenhXoa = new RoutedUICommand();
        public static RoutedUICommand lenhSua = new RoutedUICommand();
        public WindowHanghoa()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hoadonContext db = new hoadonContext();
            dgHanghoa.ItemsSource=db.Hanghoas.ToList();
        }

        private void them_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Hanghoa hh = gridHanghoa.DataContext as Hanghoa;
            hoadonContext db = new hoadonContext();
            db.Hanghoas.Add(hh);
            db.SaveChanges();

            dgHanghoa.ItemsSource = db.Hanghoas.ToList();
        }

        private void them_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Hanghoa hh = gridHanghoa.DataContext as Hanghoa;
            hoadonContext db = new hoadonContext();
            if (hh==null || string.IsNullOrEmpty(hh.Mahang))
            {
                e.CanExecute = false;
                return;
            } 
            if (db.Hanghoas.Find(hh.Mahang) != null)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true; //Nút lệnh có hiệu lực và ngược lại
            
        }

        private void xoa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Hanghoa hh = dgHanghoa.SelectedItem as Hanghoa;
            hoadonContext db = new hoadonContext();
            Hanghoa x = db.Hanghoas.Find(hh.Mahang);
            if (x != null) 
            { 
                db.Hanghoas.Remove(x);
                db.SaveChanges();
                dgHanghoa.ItemsSource = db.Hanghoas.ToList();
            }
            
        }
        private void xoa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(dgHanghoa==null || dgHanghoa.SelectedItem==null)
            {
                e.CanExecute = false;
                return;
            }
            Hanghoa hh = dgHanghoa.SelectedItem as Hanghoa;
            hoadonContext db = new hoadonContext();
            foreach (Chitiethoadon ct in db.Chitiethoadons.Where(c => c.Mahang == hh.Mahang))
            {
                e.CanExecute = false ;
                return;
            }    
            e.CanExecute=true;
        }

        private void sua_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Hanghoa hh = gridHanghoa.DataContext as Hanghoa;
            hoadonContext db = new hoadonContext();
            Hanghoa x = db.Hanghoas.Find(hh.Mahang);
            if (x != null)
            {
                x.Tenhang = hh.Tenhang;
                x.Dvt = hh.Dvt;
                x.Dongia = hh.Dongia;
                db.SaveChanges();
                dgHanghoa.ItemsSource = db.Hanghoas.ToList();
            }    

        }

        private void sua_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Hanghoa hh = gridHanghoa.DataContext as Hanghoa ;
            hoadonContext db = new hoadonContext();
            if (db.Hanghoas.Find(hh.Mahang) == null)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute =true;
        }

        private void dgHanghoa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgHanghoa==null || dgHanghoa.SelectedItem==null)
            {
                return;
            }    
            Hanghoa hh = dgHanghoa.SelectedItem as Hanghoa ;
            Hanghoa x = new Hanghoa();
            x.Mahang = hh.Mahang;
            x.Tenhang = hh.Tenhang; 
            x.Dvt = hh.Dvt;
            x.Dongia = hh.Dongia;
            gridHanghoa.DataContext = x;

        }
    }
}
