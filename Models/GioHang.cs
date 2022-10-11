using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class GioHang
    {
        public virtual Sach sach { get; set; }
        public int SoLuong { get; set; }
    }
}