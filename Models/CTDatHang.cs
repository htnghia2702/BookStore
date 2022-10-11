namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDatHang")]
    public partial class CTDatHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoDH { get; set; }

        public int? Soluong { get; set; }

        public decimal? Dongia { get; set; }

        public decimal? Thanhtien { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
