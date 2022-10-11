using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        QLSachBD db = new QLSachBD();
       
        [HttpGet]
        public ActionResult Index(int MaCD=-1, int page = 1)
        {
            
            if(MaCD != -1)
            {
                ViewBag.title = db.ChuDes.Find(MaCD).Tenchude.ToUpper();
                var ds = db.Saches.Where(s => s.MaCD == MaCD).OrderBy(o=>o.MaSach);
                int pageSize = 6;
                int pageCount = ds.Count() / pageSize + (ds.Count() % pageSize == 0 ? 0 : 1);
                ViewBag.pageCount = pageCount;
                ViewBag.page = page;
                return View(ds.Skip((page -1) * pageSize).Take(pageSize).ToList());
            }
            else
            {
                ViewBag.title = "SÁCH MỚI";
                var ds = db.Saches.OrderByDescending(o => o.Ngaycapnhat).Take(6);
                return View(ds.ToList());
            }
            
        }
        public ActionResult Menu()
        {
            return PartialView(db.ChuDes.ToList());
        }
        [HttpGet]
        public ActionResult ChiTiet(int MaSach)
        {
            var sach = db.Saches.Find(MaSach);
            return View(sach);
        }
        public ActionResult SachLienQuan(int MaCD,int MaSach)
        {
            var ds = db.Saches.Where(s => s.MaCD == MaCD && s.MaSach != MaSach);
            return PartialView(ds.Take(4).ToList());
        }
    }
}