﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppHoadon.UI;

namespace WpfAppHoadon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuHanghoa_Click(object sender, RoutedEventArgs e)
        {
            WindowHanghoa f = new WindowHanghoa();    
            f.Show();
        }

        private void menuHoadon_Click(object sender, RoutedEventArgs e)
        {
            WindowHoadon f = new WindowHoadon();
            f.Show();
        }

        private void menuHangHoaMVVM_Click(object sender, RoutedEventArgs e)
        {
            HanghoaMVVM f = new HanghoaMVVM();
            f.Show();
        }

        private void testMVVM_Click(object sender, RoutedEventArgs e)
        {
            WindowTest f = new WindowTest();
            f.Show();
        }
    }
}