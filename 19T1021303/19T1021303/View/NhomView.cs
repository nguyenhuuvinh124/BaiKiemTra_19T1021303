using _19T1021303.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021303.View
{
    public class NhomView
    {
        public int ID { get; set; }
        public string TenNhom { get; set; }

        public static void ThemNhom(Nhom nhom)
        {
            var db = new Model1();
            var rs = db.Nhom.Add(nhom);
            db.SaveChanges();
        }

        public static List<NhomView> GetList()
        {
            var db = new Model1();
            var rs = db.Nhom.Select(e => new NhomView
            {
                ID = e.ID,
                TenNhom = e.TenNhom,
            }).ToList();
            return rs;
        }

        public static void XoaNhom(int id)
        {
            var db = new Model1();
            var lienlac = db.Nhom.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.Nhom.Remove(lienlac);
            db.SaveChanges();
        }
    }
}
