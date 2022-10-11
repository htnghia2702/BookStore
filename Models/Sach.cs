namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CTDatHangs = new HashSet<CTDatHang>();
            VietSaches = new HashSet<VietSach>();
        }

        [Key]
        public int MaSach { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="Tên sách rỗng !")]
        public string TenSach { get; set; }

        public int? MaCD { get; set; }

        public int? MaNXB { get; set; }

        [Required(ErrorMessage ="Đơn giá rỗng !")]
        [Range(1,100000000,ErrorMessage ="Đơn giá không hợp lệ !")]
        public decimal? Dongia { get; set; }

        public string Mota { get; set; }

        [StringLength(100)]
        public string AnhBia { get; set; }

        public DateTime? Ngaycapnhat { get; set; }

        public int? Soluotxem { get; set; }

        public virtual ChuDe ChuDe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDatHang> CTDatHangs { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VietSach> VietSaches { get; set; }
    }
}
