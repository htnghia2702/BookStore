namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VaiTro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenVaiTro = c.String(),
                        ChiTiet = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.KhachHang", "VaiTro_Id", c => c.Int());
            CreateIndex("dbo.KhachHang", "VaiTro_Id");
            AddForeignKey("dbo.KhachHang", "VaiTro_Id", "dbo.VaiTro", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhachHang", "VaiTro_Id", "dbo.VaiTro");
            DropIndex("dbo.KhachHang", new[] { "VaiTro_Id" });
            DropColumn("dbo.KhachHang", "VaiTro_Id");
            DropTable("dbo.VaiTro");
        }
    }
}
