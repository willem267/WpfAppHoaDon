using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppHoadon.Models;
using WpfAppHoadon.ViewModels;

namespace WpfAppHoadon.MyModels
{
     class WindowtestVM : CBaseMVVM
    {
        public WindowtestVM()
        {
            hoadonContext db = new hoadonContext();
            listHanghoa = db.Hanghoas.Select(t=>CHanghoa.chuyendoi(t)).ToList();
        }

        private CHanghoa _selectionHanghoa;
        public CHanghoa selectionHanghoa
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
                    _selectionHanghoa.Parent = this;
                    //Mahang = _selectionHanghoa.Mahang;
                    //Tenhang = _selectionHanghoa.Tenhang;
                    //Dvt = _selectionHanghoa.Dvt;
                    //Dongia = _selectionHanghoa.Dongia.ToString();
                }
            }
        }
        private List<CHanghoa> _listHanghoa;
        public List<CHanghoa> listHanghoa
        {
            get { return _listHanghoa; }
            set
            {
                _listHanghoa = value;
                NotifyPropertyChanged("listHanghoa");
            }
        }
    }
}
