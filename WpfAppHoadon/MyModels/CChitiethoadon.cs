using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppHoadon.Models;

namespace WpfAppHoadon.MyModels
{
    class CChitiethoadon
    {
        public string Sohd { get; set; }
        public string Mahang { get; set; }
        public double? Dongia { get; set; }
        public int? Soluong { get; set; }
        public string Tenhang { 
            get
            {
                if (MahangNavigation == null)
                {
                    return string.Empty;
                }
                else
                return MahangNavigation.Tenhang;
            }
        }
        public string Dvt
        {
            get
            {
                if (MahangNavigation == null)
                {
                    return string.Empty;
                }
                else
                    return MahangNavigation.Dvt;
            }
        }
        public double Thanhtien
        {
            get
            {
                if (Dongia.HasValue == false || Soluong.HasValue == false)
                {
                    return 0;
                }
                else
                    return Dongia.Value * Soluong.Value;
            }
        }
        public Hanghoa MahangNavigation { get; set; }
        public static CChitiethoadon chuyendoi(Chitiethoadon c)
        {
            return new CChitiethoadon
            {
                Sohd = c.Sohd,
                Mahang = c.Mahang,
                Dongia = c.Dongia,
                Soluong = c.Soluong,
                MahangNavigation = c.MahangNavigation
            };
        }
        public static Chitiethoadon chuyendoi(CChitiethoadon c)
        {
            return new Chitiethoadon
            {
                Sohd = c.Sohd,
                Mahang = c.Mahang,
                Dongia = c.Dongia,
                Soluong = c.Soluong,
                //MahangNavigation = c.MahangNavigation
            };
        }
    }
}
