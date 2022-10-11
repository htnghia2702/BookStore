using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                List<GioHang> dsCart = Session["cart"] as List<GioHang>;
                if (dsCart == null)
                {
                    return HttpNotFound();
                }
                return View(dsCart);
            }
            else
            {
                return RedirectToAction("Index", "DangNhap");
            }
            
        }
        [HttpPost]
        public ActionResult DatHang( string ngaygiao)
        {
            QLSachBD db = new QLSachBD();
            List<GioHang> dsCart = Session["cart"] as List<GioHang>;
            //lưu vào đơn đặt hàng
            var kh = Session["user"] as KhachHang;
            DonDatHang donhang = new DonDatHang();
            donhang.MaKH = kh.MaKH;
            donhang.NgayDH = DateTime.Now;
            donhang.Trigia =(decimal)dsCart.Sum(s => s.sach.Dongia * s.SoLuong);
            donhang.Ngaygiao = DateTime.Parse(ngaygiao);
            donhang.Dagiao = false;
            db.DonDatHangs.Add(donhang);
            db.SaveChanges();
            //lưu vào chi tiết đơn đặt hàng
            int SoDH = donhang.SoDH;
            foreach(var item in dsCart)
            {
                db.CTDatHangs.Add(new CTDatHang { MaSach = item.sach.MaSach, SoDH = SoDH, Soluong = item.SoLuong, Dongia = item.sach.Dongia, Thanhtien = (item.sach.Dongia * item.SoLuong) });
            }
            db.SaveChanges();
            Session["cart"] = null;
            Session["count"] = null;
            return View();
        }
    }
}