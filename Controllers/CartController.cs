using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        QLSachBD db = new QLSachBD();
        public ActionResult Index()
        {
            List<GioHang> dsCart = Session["cart"] as List<GioHang>;
            if(dsCart != null)
            {
                ViewBag.tongTien = dsCart.Sum(s => s.sach.Dongia * s.SoLuong);
            }
            return View(dsCart);
        }
        [HttpPost]
        public ActionResult addCart(int MaSach,int SL,string ac)
        {
            if (Session["cart"] == null)
            {
                List<GioHang> dsCart = new List<GioHang>();
                dsCart.Add(new GioHang { sach = db.Saches.Find(MaSach), SoLuong = SL });
                Session["cart"] = dsCart;
                Session["count"] = dsCart.Count();
            }
            else
            {
                List<GioHang> dsCart = Session["cart"] as List<GioHang>;
                int index = KiemTraCart(MaSach);
                if(index != -1)
                {
                    if (ac == "add")
                    {
                        dsCart[index].SoLuong += 1;
                    }
                    else
                    {
                        dsCart[index].SoLuong =SL;
                    }
                }
                else
                {
                    dsCart.Add(new GioHang { sach = db.Saches.Find(MaSach), SoLuong = SL });
                }
                Session["cart"] = dsCart;
                Session["count"] = dsCart.Count();
            }
            return Content(MaSach.ToString());
        }
        [HttpPost]
        public ActionResult DeleteCart(int MaSach)
        {
            List<GioHang> dsCart = Session["cart"] as List<GioHang>;
            dsCart.Remove(dsCart.Find(x => x.sach.MaSach == MaSach));
            Session["count"] = (int)Session["count"] - 1;
            Session["cart"] = dsCart;
            return Content(MaSach.ToString());
        }
        [HttpPost]
        public ActionResult DeleteAll()
        {
            Session["cart"] = null;
            Session["count"] = 0;
            return Content("");
        }
        public int KiemTraCart(int Masach)
        {
            List<GioHang> dsCart = Session["cart"] as List<GioHang>;
            for(int i =0; i<dsCart.Count(); i++)
            {
                if (dsCart[i].sach.MaSach == Masach)
                    return i;
            }
            return -1;
        }
    }
}