namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelabc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Hp = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Accounts_Id = c.Int(),
                        DetailHotels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Accounts_Id)
                .ForeignKey("dbo.DetailHotels", t => t.DetailHotels_Id)
                .Index(t => t.Accounts_Id)
                .Index(t => t.DetailHotels_Id);
            
            CreateTable(
                "dbo.DetailHotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Room = c.String(),
                        Price = c.Double(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Districts_Id = c.Int(),
                        Hotels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.Districts_Id)
                .ForeignKey("dbo.Hotels", t => t.Hotels_Id)
                .Index(t => t.Districts_Id)
                .Index(t => t.Hotels_Id);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Villages_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Villages", t => t.Villages_Id)
                .Index(t => t.Villages_Id);
            
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Star = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Regencies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regencies", t => t.Regencies_Id)
                .Index(t => t.Regencies_Id);
            
            CreateTable(
                "dbo.Regencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Districts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.Districts_Id)
                .Index(t => t.Districts_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provinces", "Regencies_Id", "dbo.Regencies");
            DropForeignKey("dbo.Regencies", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Bookings", "DetailHotels_Id", "dbo.DetailHotels");
            DropForeignKey("dbo.DetailHotels", "Hotels_Id", "dbo.Hotels");
            DropForeignKey("dbo.DetailHotels", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Districts", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Bookings", "Accounts_Id", "dbo.Accounts");
            DropIndex("dbo.Regencies", new[] { "Districts_Id" });
            DropIndex("dbo.Provinces", new[] { "Regencies_Id" });
            DropIndex("dbo.Districts", new[] { "Villages_Id" });
            DropIndex("dbo.DetailHotels", new[] { "Hotels_Id" });
            DropIndex("dbo.DetailHotels", new[] { "Districts_Id" });
            DropIndex("dbo.Bookings", new[] { "DetailHotels_Id" });
            DropIndex("dbo.Bookings", new[] { "Accounts_Id" });
            DropTable("dbo.Regencies");
            DropTable("dbo.Provinces");
            DropTable("dbo.Hotels");
            DropTable("dbo.Villages");
            DropTable("dbo.Districts");
            DropTable("dbo.DetailHotels");
            DropTable("dbo.Bookings");
            DropTable("dbo.Accounts");
        }
    }
}
