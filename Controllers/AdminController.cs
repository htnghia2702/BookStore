using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        
        QLSachBD db = new QLSachBD();         
        public ActionResult Index()
        {
            
            int pageSize = 10;
            var dsSach = db.Saches.OrderBy(s => s.MaSach).ToList();
            ViewBag.pageCount = Math.Ceiling(1.0 * dsSach.Count() / pageSize);
            return View();
        }
    
        public ActionResult List(int page=1)
        {
            int pageSize = 10;           
            var dsSach = db.Saches.OrderBy(s=>s.MaSach).ToList();
            return PartialView(dsSach.Skip((page-1) * pageSize).Take(pageSize));
        }
        [HttpPost]
        public ActionResult Search(string name)
        {
            
            var dsSach = db.Saches.Where(s => s.TenSach.ToUpper().Contains(name.ToUpper()));
            return PartialView("List",dsSach.ToList());
        }        
        public ActionResult ThemSach()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult ThemSach(Sach s)
        {
            
            var file = Request.Files["AnhBia"];
            if (file.FileName.Length == 0)
            {
                ModelState.AddModelError("loi", "Vui lòng chọn ảnh !");
                return View();
            }
            else
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/jpg" || file.ContentType == "image/gif")
                {
                    s.AnhBia = file.FileName;
                    string url = Server.MapPath("~/Bia_sach/" + file.FileName);
                    file.SaveAs(url);
                }
                else
                {
                    ModelState.AddModelError("loi", "Hình ảnh có định dạng ( jpeg / png / jpg / gif)");
                    return View();
                }
            }
            db.Saches.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            
            var kq = db.Saches.Find(id);
            db.Saches.Remove(kq);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult CapNhat(int id)
        {
            var kq = db.Saches.Find(id);
            
            return View(kq);
        }
        [HttpPost]
        public ActionResult CapNhat(Sach sach)
        {
            Sach s = db.Saches.Find(sach.MaSach);
            var file = Request.Files["AnhBia"];
            if (file.FileName.Length > 0)
            {
                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png" || file.ContentType == "image/jpg" || file.ContentType == "image/gif")
                {
                    string url = Server.MapPath("~/Bia_sach/" + file.FileName);
                    file.SaveAs(url);
                    s.AnhBia = file.FileName;
                }
                else
                {
                    ModelState.AddModelError("loi", "Hình ảnh có định dạng ( .jpeg / .png / .jpg / .gif)");
                    return View(s);
                }
            }
            s.TenSach = sach.TenSach;
            s.MaCD = sach.MaCD;
            s.MaNXB = sach.MaNXB;
            s.Dongia = sach.Dongia;
            s.Mota = sach.Mota;
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");          
        }
  
        public ActionResult DonHang()
        {
            
            return View(db.DonDatHangs.OrderByDescending(o=>o.NgayDH).ToList());
        }
        [HttpPost]
        public ActionResult TrangThai(int SoDH)
        {
            string mess = "";
            DonDatHang kq = db.DonDatHangs.Find(SoDH);
            if (kq.Dagiao == false)
            {
                kq.Dagiao = true;
                mess = "Đã cập nhật đơn hàng " + SoDH + " đã giao !";
            }
            else
            {
                kq.Dagiao = false;
                mess = "Đã cập nhật đơn hàng " + SoDH + " chưa giao !";
            }
            db.SaveChanges();
            return Content(mess);
        }
        public ActionResult CTDonHang(int SoDH)
        {
            var kq = db.CTDatHangs.Where(d => d.SoDH == SoDH);           
            return View(kq.ToList());
        }
        [HttpPost]
        public ActionResult XoaDH(int SoDH)
        {
            var kq = db.CTDatHangs.Where(s => s.SoDH == SoDH);
            db.CTDatHangs.RemoveRange(kq);
            db.SaveChanges();
            db.DonDatHangs.Remove(db.DonDatHangs.Find(SoDH));
            db.SaveChanges();
            return Content(SoDH.ToString());
        }
    }
}