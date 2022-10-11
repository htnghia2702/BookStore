namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonDatHangs = new HashSet<DonDatHang>();
        }

        [Key]
        public int MaKH { get; set; }
        [StringLength(50)]      
        public string HoTenKH { get; set; }
        [StringLength(150)]
        public string Diachi { get; set; }
        [StringLength(15)]     
        public string Dienthoai { get; set; }
        [StringLength(15)]    
        public string TenDN { get; set; }
        [StringLength(15)]     
        public string Matkhau { get; set; }      
        public DateTime? Ngaysinh { get; set; }
        [StringLength(50)]        
        public string Email { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }  
        public virtual VaiTro VaiTro { set; get; }
        

    }
}
