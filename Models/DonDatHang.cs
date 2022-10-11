namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            CTDatHangs = new HashSet<CTDatHang>();
        }

        [Key]
        public int SoDH { get; set; }

        public int? MaKH { get; set; }

        public DateTime? NgayDH { get; set; }

        public decimal? Trigia { get; set; }

        public bool? Dagiao { get; set; }

        public DateTime? Ngaygiao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDatHang> CTDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
