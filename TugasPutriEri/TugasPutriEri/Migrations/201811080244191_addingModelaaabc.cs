namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelaaabc : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailHotels", "Hotels_Id", "dbo.Hotels");
            DropForeignKey("dbo.Bookings", "DetailHotels_Id", "dbo.DetailHotels");
            DropIndex("dbo.Bookings", new[] { "DetailHotels_Id" });
            DropIndex("dbo.DetailHotels", new[] { "Hotels_Id" });
            CreateTable(
                "dbo.DetailRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Facilities_Id = c.Int(),
                        Rooms_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Facilities", t => t.Facilities_Id)
                .ForeignKey("dbo.Rooms", t => t.Rooms_Id)
                .Index(t => t.Facilities_Id)
                .Index(t => t.Rooms_Id);
            
            AddColumn("dbo.Bookings", "DetailRooms_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "DetailRooms_Id");
            AddForeignKey("dbo.Bookings", "DetailRooms_Id", "dbo.DetailRooms", "Id");
            DropColumn("dbo.Bookings", "DetailHotels_Id");
            DropTable("dbo.DetailHotels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DetailHotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Hotels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "DetailHotels_Id", c => c.Int());
            DropForeignKey("dbo.Bookings", "DetailRooms_Id", "dbo.DetailRooms");
            DropForeignKey("dbo.DetailRooms", "Rooms_Id", "dbo.Rooms");
            DropForeignKey("dbo.DetailRooms", "Facilities_Id", "dbo.Facilities");
            DropIndex("dbo.DetailRooms", new[] { "Rooms_Id" });
            DropIndex("dbo.DetailRooms", new[] { "Facilities_Id" });
            DropIndex("dbo.Bookings", new[] { "DetailRooms_Id" });
            DropColumn("dbo.Bookings", "DetailRooms_Id");
            DropTable("dbo.DetailRooms");
            CreateIndex("dbo.DetailHotels", "Hotels_Id");
            CreateIndex("dbo.Bookings", "DetailHotels_Id");
            AddForeignKey("dbo.Bookings", "DetailHotels_Id", "dbo.DetailHotels", "Id");
            AddForeignKey("dbo.DetailHotels", "Hotels_Id", "dbo.Hotels", "Id");
        }
    }
}
