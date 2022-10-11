namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChuDe",
                c => new
                    {
                        MaCD = c.Int(nullable: false, identity: true),
                        Tenchude = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaCD);
            
            CreateTable(
                "dbo.Sach",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(nullable: false, maxLength: 100),
                        MaCD = c.Int(),
                        MaNXB = c.Int(),
                        Dongia = c.Decimal(nullable: false, precision: 10, scale: 2),
                        Mota = c.String(),
                        AnhBia = c.String(maxLength: 100),
                        Ngaycapnhat = c.DateTime(),
                        Soluotxem = c.Int(),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.ChuDe", t => t.MaCD)
                .ForeignKey("dbo.NhaXuatBan", t => t.MaNXB)
                .Index(t => t.MaCD)
                .Index(t => t.MaNXB);
            
            CreateTable(
                "dbo.CTDatHang",
                c => new
                    {
                        MaSach = c.Int(nullable: false),
                        SoDH = c.Int(nullable: false),
                        Soluong = c.Int(),
                        Dongia = c.Decimal(precision: 10, scale: 2),
                        Thanhtien = c.Decimal(precision: 10, scale: 2),
                    })
                .PrimaryKey(t => new { t.MaSach, t.SoDH })
                .ForeignKey("dbo.DonDatHang", t => t.SoDH)
                .ForeignKey("dbo.Sach", t => t.MaSach)
                .Index(t => t.MaSach)
                .Index(t => t.SoDH);
            
            CreateTable(
                "dbo.DonDatHang",
                c => new
                    {
                        SoDH = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(),
                        NgayDH = c.DateTime(),
                        Trigia = c.Decimal(precision: 10, scale: 2),
                        Dagiao = c.Boolean(),
                        Ngaygiao = c.DateTime(),
                    })
                .PrimaryKey(t => t.SoDH)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        HoTenKH = c.String(maxLength: 50),
                        Diachi = c.String(maxLength: 150),
                        Dienthoai = c.String(maxLength: 15),
                        TenDN = c.String(maxLength: 15),
                        Matkhau = c.String(maxLength: 15),
                        Ngaysinh = c.DateTime(),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhaXuatBan",
                c => new
                    {
                        MaNXB = c.Int(nullable: false, identity: true),
                        TenNXB = c.String(maxLength: 100),
                        Diachi = c.String(maxLength: 150),
                        Dienthoai = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.MaNXB);
            
            CreateTable(
                "dbo.VietSach",
                c => new
                    {
                        MaTG = c.Int(nullable: false),
                        MaSach = c.Int(nullable: false),
                        Vaitro = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.MaTG, t.MaSach })
                .ForeignKey("dbo.TacGia", t => t.MaTG)
                .ForeignKey("dbo.Sach", t => t.MaSach)
                .Index(t => t.MaTG)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.TacGia",
                c => new
                    {
                        MaTG = c.Int(nullable: false, identity: true),
                        TenTG = c.String(maxLength: 50),
                        Diachi = c.String(maxLength: 150),
                        Dienthoai = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.MaTG);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VietSach", "MaSach", "dbo.Sach");
            DropForeignKey("dbo.VietSach", "MaTG", "dbo.TacGia");
            DropForeignKey("dbo.Sach", "MaNXB", "dbo.NhaXuatBan");
            DropForeignKey("dbo.CTDatHang", "MaSach", "dbo.Sach");
            DropForeignKey("dbo.DonDatHang", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.CTDatHang", "SoDH", "dbo.DonDatHang");
            DropForeignKey("dbo.Sach", "MaCD", "dbo.ChuDe");
            DropIndex("dbo.VietSach", new[] { "MaSach" });
            DropIndex("dbo.VietSach", new[] { "MaTG" });
            DropIndex("dbo.DonDatHang", new[] { "MaKH" });
            DropIndex("dbo.CTDatHang", new[] { "SoDH" });
            DropIndex("dbo.CTDatHang", new[] { "MaSach" });
            DropIndex("dbo.Sach", new[] { "MaNXB" });
            DropIndex("dbo.Sach", new[] { "MaCD" });
            DropTable("dbo.TacGia");
            DropTable("dbo.VietSach");
            DropTable("dbo.NhaXuatBan");
            DropTable("dbo.KhachHang");
            DropTable("dbo.DonDatHang");
            DropTable("dbo.CTDatHang");
            DropTable("dbo.Sach");
            DropTable("dbo.ChuDe");
        }
    }
}
