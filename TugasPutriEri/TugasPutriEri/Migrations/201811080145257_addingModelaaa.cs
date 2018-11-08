namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelaaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetailHotels", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.DetailHotels", "Facilities_Id", "dbo.Facilities");
            DropForeignKey("dbo.DetailHotels", "Rooms_Id", "dbo.Rooms");
            DropIndex("dbo.DetailHotels", new[] { "Districts_Id" });
            DropIndex("dbo.DetailHotels", new[] { "Facilities_Id" });
            DropIndex("dbo.DetailHotels", new[] { "Rooms_Id" });
            AddColumn("dbo.Hotels", "Rooms_Id", c => c.Int());
            AddColumn("dbo.Rooms", "Facilities_Id", c => c.Int());
            CreateIndex("dbo.Hotels", "Rooms_Id");
            CreateIndex("dbo.Rooms", "Facilities_Id");
            AddForeignKey("dbo.Rooms", "Facilities_Id", "dbo.Facilities", "Id");
            AddForeignKey("dbo.Hotels", "Rooms_Id", "dbo.Rooms", "Id");
            DropColumn("dbo.DetailHotels", "Districts_Id");
            DropColumn("dbo.DetailHotels", "Facilities_Id");
            DropColumn("dbo.DetailHotels", "Rooms_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetailHotels", "Rooms_Id", c => c.Int());
            AddColumn("dbo.DetailHotels", "Facilities_Id", c => c.Int());
            AddColumn("dbo.DetailHotels", "Districts_Id", c => c.Int());
            DropForeignKey("dbo.Hotels", "Rooms_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Facilities_Id", "dbo.Facilities");
            DropIndex("dbo.Rooms", new[] { "Facilities_Id" });
            DropIndex("dbo.Hotels", new[] { "Rooms_Id" });
            DropColumn("dbo.Rooms", "Facilities_Id");
            DropColumn("dbo.Hotels", "Rooms_Id");
            CreateIndex("dbo.DetailHotels", "Rooms_Id");
            CreateIndex("dbo.DetailHotels", "Facilities_Id");
            CreateIndex("dbo.DetailHotels", "Districts_Id");
            AddForeignKey("dbo.DetailHotels", "Rooms_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.DetailHotels", "Facilities_Id", "dbo.Facilities", "Id");
            AddForeignKey("dbo.DetailHotels", "Districts_Id", "dbo.Districts", "Id");
        }
    }
}
