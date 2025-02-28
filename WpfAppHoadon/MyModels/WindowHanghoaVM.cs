using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppHoadon.Models;
using WpfAppHoadon.ViewModels;

namespace WpfAppHoadon.MyModels
{
    class WindowHanghoaVM : CBaseMVVM
    {
        public WindowHanghoaVM()
        {
            hoadonContext db = new hoadonContext();
            listHanghoa = db.Hanghoas.ToList();
            lenhXoa = new RelayCommand(lenhXoa_Execute, lenhXoa_CanExecute);
            lenhThem = new RelayCommand(lenhThem_Execute, lenhThem_CanExecute);
            lenhSua = new RelayCommand(lenhSua_Execute, lenhSua_CanExecute);
        }
        private string _mahang;
        public string Mahang
        {
            get
            {
                return _mahang;
            }
            set
            {
                _mahang = value;
                NotifyPropertyChanged("Mahang");
            }
        }
        private string _tenhang;
        public string Tenhang
        {
            get
            {
                return _tenhang;
            }
            set
            {
                _tenhang = value;
                NotifyPropertyChanged("Tenhang");
            }
        }
        private string _dvt;
        public string Dvt
        {
            get
            {
                return _dvt;
            }
            set
            {
                _dvt = value;
                NotifyPropertyChanged("Dvt");
            }
        }
        private string _dongia;
        public string Dongia 
        {
            get
            {
                return _dongia;
            }
            set
            {
                _dongia = value;
                NotifyPropertyChanged("Dongia");
            }
        }
        private Hanghoa _selectionHanghoa;
        public Hanghoa selectionHanghoa
        {
            get
            {
                return _selectionHanghoa;
            }
            set
            {
                _selectionHanghoa = value;
                if (_selectionHanghoa != null)
                {
                    Mahang = _selectionHanghoa.Mahang;
                    Tenhang = _selectionHanghoa.Tenhang;
                    Dvt = _selectionHanghoa.Dvt;
                    Dongia = _selectionHanghoa.Dongia.ToString();
                }
            }
        }
        private List<Hanghoa> _listHanghoa;
        public List<Hanghoa> listHanghoa
        {
            get { return _listHanghoa; }
            set
            {
                _listHanghoa = value;
                NotifyPropertyChanged("listHanghoa");
            }
        }
        public RelayCommand lenhXoa { get; set; }
        public void lenhXoa_Execute(object parameter)
        {
            hoadonContext db = new hoadonContext();
            db.Hanghoas.Remove(selectionHanghoa);
            db.SaveChanges();
            listHanghoa = db.Hanghoas.ToList();
        }
        public bool lenhXoa_CanExecute(object parameter)
        {
            if (selectionHanghoa == null)
                return false;
            hoadonContext db = new hoadonContext();
            if (db.Chitiethoadons.Count(t => t.Mahang == selectionHanghoa.Mahang) > 0)
                return false;
            return true;
        }

        //lenh them
        public RelayCommand lenhThem { get; set; }
        public void lenhThem_Execute(object parameter)
        {
            hoadonContext db = new hoadonContext();
            Hanghoa hh = new Hanghoa();
            hh.Mahang = Mahang;
            hh.Tenhang = Tenhang;
            hh.Dvt = Dvt;
            hh.Dongia = double.Parse(Dongia);
            db.Hanghoas.Add(hh);
            db.SaveChanges();

            listHanghoa = db.Hanghoas.ToList();
        }
        public bool lenhThem_CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Mahang) || string.IsNullOrEmpty(Tenhang) || string.IsNullOrEmpty(Dvt) || string.IsNullOrEmpty(Dongia))
                return false;
            hoadonContext db = new hoadonContext();
            if (db.Hanghoas.Find(Mahang) != null)
                return false;
            double dg;
            if (double.TryParse(Dongia, out dg) == false)
                return false;
            return true;
        }

        //lenh sua
        public RelayCommand lenhSua { get; set; }
        public void lenhSua_Execute(object parameter)
        {
            
            hoadonContext db = new hoadonContext();
            Hanghoa hh = new Hanghoa();
            hh.Mahang = Mahang;
            hh.Tenhang = Tenhang;
            hh.Dvt = Dvt;
            hh.Dongia = double.Parse(Dongia);
            db.Hanghoas.Update(hh);
            db.SaveChanges();

            listHanghoa = db.Hanghoas.ToList();
        }
        public bool lenhSua_CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Mahang) || string.IsNullOrEmpty(Tenhang) || string.IsNullOrEmpty(Dvt) || string.IsNullOrEmpty(Dongia))
                return false;
            hoadonContext db = new hoadonContext();
            if (db.Hanghoas.Find(Mahang) == null)
                return false;
            double dg;
            if (double.TryParse(Dongia, out dg) == false)
                return false;
            return true;
        }


    }
}
