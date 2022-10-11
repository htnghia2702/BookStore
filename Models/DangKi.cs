using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DangKi
    {
        [Required(ErrorMessage ="Họ tên rỗng !")]
        public string HoTenKH { get; set; }  
        public string Diachi { get; set; }

        [Required(ErrorMessage = "Điện thoại rỗng !")]
        [RegularExpression("0[0-9]{9}",ErrorMessage ="Số điện thoại không hợp lệ !")]
        public string Dienthoai { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập rỗng !")]
        public string TenDN { get; set; }

        [Required(ErrorMessage = "Mật khẩu rỗng !")]
        public string Matkhau { get; set; }

        [Required(ErrorMessage ="Mật khẩu nhập lại rỗng !")]
        [Compare("Matkhau", ErrorMessage ="Mật khẩu nhập lại không đúng !")]
        public string MatKhauNL { get; set; }

        public DateTime? Ngaysinh { get; set; }

        [EmailAddress(ErrorMessage ="Email không hợp lệ !")]
        public string Email { get; set; }
    }
}