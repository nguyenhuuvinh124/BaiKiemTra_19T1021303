using _19T1021303.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021303.View
{
    public class NguoiView
    {
        public int ID { get; set; }

        public string TenGoi { get; set; }

        public string Email { get; set; }

        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public int? IDNhom { get; set; }

        public static List<NguoiView> GetListByID(int ID)
        {

            var db = new Model1();
            var rs = db.Nguoi.Where(e => e.IDNhom == ID).Select(e => new NguoiView
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }
        public static List<NguoiView> GetListAll()
        {

            var db = new Model1();
            var rs = db.Nguoi.Select(e => new NguoiView
            {
                ID = e.ID,
                TenGoi = e.TenGoi,
                Email = e.Email,
                SDT = e.SDT,
                DiaChi = e.DiaChi,
                IDNhom = e.IDNhom,
            }).ToList();
            return rs;
        }

        public static void ThemNguoi(Nguoi nguoi)
        {
            var db = new Model1();
            var rs = db.Nguoi.Add(nguoi);
            db.SaveChanges();
        }

        public static void XoaNguoi(int id)
        {
            var db = new Model1();
            var nguoi = db.Nguoi.Where(e => e.ID == id).FirstOrDefault();
            var rs = db.Nguoi.Remove(nguoi);
            db.SaveChanges();
        }
    }
}
