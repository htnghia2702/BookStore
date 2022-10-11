using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string TenDN,string MatKhau)
        {
            QLSachBD db = new QLSachBD();
            ViewBag.tendn = TenDN;
            ViewBag.matkhau = MatKhau;
            if (TenDN == "")
                ModelState.AddModelError("dangnhap", "Tên đăng nhập rỗng !");
            else if(MatKhau == "")
            {
                ModelState.AddModelError("dangnhap", "Mật khẩu rỗng !");
            }
            else
            {             
                KhachHang kh = db.KhachHangs.Where(k => k.TenDN == TenDN && k.Matkhau == MatKhau).FirstOrDefault();
                if (kh != null)
                {

                    //FormsAuthentication.SetAuthCookie((kh.VaiTro==null?"KhachHang": kh.VaiTro.TenVaiTro), false);
                    if (kh.VaiTro.Id == 2) //admin
                    {
                        FormsAuthentication.SetAuthCookie(TenDN, true);
                    }
                    Session["user"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("dangnhap", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View();
            
        }
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKi(DangKi kh)
        {
            QLSachBD db = new QLSachBD();
            if (KTTaiKhoan(kh.TenDN))
            {
                ModelState.AddModelError("eror", "Tên đăng nhập đã tồn tại !");
                return View();
            }
            else
            {
                db.KhachHangs.Add(new KhachHang {HoTenKH=kh.HoTenKH,TenDN=kh.TenDN,Matkhau=kh.Matkhau,Diachi=kh.Diachi,Ngaysinh=kh.Ngaysinh,Email=kh.Email,Dienthoai = kh.Dienthoai,});
                db.SaveChanges();
            }
            return RedirectToAction("Index", "DangNhap");
        }
        public ActionResult DangXuat()
        {
            Session["user"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public Boolean KTTaiKhoan(string TenDN)
        {
            QLSachBD db = new QLSachBD();
            foreach(var item in db.KhachHangs)
            {
                if (item.TenDN == TenDN)
                    return true;
            }
            return false;
        }
    }
}