using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppHoadon.Models;

namespace WpfAppHoadon.MyModels
{
    class CHoadon
    {

        public CHoadon()
        {
            Chitiethoadons = new HashSet<CChitiethoadon>();
        }
        public string Sohd { get; set; }
        public DateTime? Ngaylaphd { get; set; }
        public string Tenkh { get; set; }
        public double Thanhtien
        {
            get
            {
                return Chitiethoadons.Sum(t => t.Thanhtien);
            }
        }
        public ICollection<CChitiethoadon> Chitiethoadons { get; set; }
        public static CHoadon chuyendoi(Hoadon h)
        {
            return new CHoadon
            {
                Sohd = h.Sohd,
                Ngaylaphd = h.Ngaylaphd,
                Tenkh = h.Tenkh,
                Chitiethoadons = h.Chitiethoadons.Select(t => CChitiethoadon.chuyendoi(t)).ToList()
            };

        }
        public static Hoadon chuyendoi(CHoadon c)
        {
            return new Hoadon
            {
                Sohd = c.Sohd,
                Ngaylaphd = c.Ngaylaphd,
                Tenkh = c.Tenkh,
                Chitiethoadons = c.Chitiethoadons.Select(t => CChitiethoadon.chuyendoi(t)).ToList()
            };
        }
        public static CHoadon saochep(CHoadon c)
        {
            CHoadon hd = new CHoadon();
            hd.Sohd = c.Sohd;
            hd.Ngaylaphd = c.Ngaylaphd;
            hd.Tenkh = c.Tenkh;
            foreach (CChitiethoadon ct in c.Chitiethoadons)
            {
                hd.Chitiethoadons.Add(ct);
            }
            return hd;
        }
    }
}
