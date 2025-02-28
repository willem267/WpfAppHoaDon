using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppHoadon.Models;
using WpfAppHoadon.ViewModels;

namespace WpfAppHoadon.MyModels
{
     class CHanghoa
    {

        public CHanghoa()
        {
            lenhXoa= new RelayCommand(lenhXoa_Execute, lenhXoa_CanExecute);
        }
        public WindowtestVM Parent { get; set; }
        public string Mahang { get; set; }
        public string Tenhang { get; set; }
        public string Dvt { get; set; }
        public double? Dongia { get; set; }
        public static CHanghoa chuyendoi(Hanghoa hh)
        {
            CHanghoa chh = new CHanghoa();
            chh.Mahang = hh.Mahang;
            chh.Tenhang = hh.Tenhang;
            chh.Dvt = hh.Dvt;
            chh.Dongia = hh.Dongia;
            return chh;
        }
        public static Hanghoa chuyendoi(CHanghoa chh)
        {
            Hanghoa hh = new Hanghoa();
            hh.Mahang = chh.Mahang;
            hh.Tenhang = chh.Tenhang;
            hh.Dvt = chh.Dvt;
            hh.Dongia = chh.Dongia;
            return hh;
        }

        public RelayCommand lenhXoa { get; set; }
        public void lenhXoa_Execute(object parameter)
        {
            hoadonContext db = new hoadonContext();
           Hanghoa x = db.Hanghoas.Find(Mahang);
            if(x != null)
            {
                db.Hanghoas.Remove(x);
                db.SaveChanges();
                Parent.listHanghoa = db.Hanghoas.Select(t=>CHanghoa.chuyendoi(t)).ToList();
            }

        }
        public bool lenhXoa_CanExecute(object parameter)
        {
           
            hoadonContext db = new hoadonContext();
            if (db.Chitiethoadons.Count(t => t.Mahang == Mahang) > 0)
                return false;
            return true;
        }
    }
}
