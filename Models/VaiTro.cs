using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    [Table("VaiTro")]
    public class VaiTro
    {
        public int Id { get; set; }
        public string TenVaiTro { get; set; }
        public string ChiTiet { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

    }
}