namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelaaa2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "Facilities_Id", "dbo.Facilities");
            DropForeignKey("dbo.Hotels", "Rooms_Id", "dbo.Rooms");
            DropIndex("dbo.Hotels", new[] { "Rooms_Id" });
            DropIndex("dbo.Rooms", new[] { "Facilities_Id" });
            AddColumn("dbo.Rooms", "Hotels_Id", c => c.Int());
            AddColumn("dbo.Facilities", "Rooms_Id", c => c.Int());
            CreateIndex("dbo.Facilities", "Rooms_Id");
            CreateIndex("dbo.Rooms", "Hotels_Id");
            AddForeignKey("dbo.Rooms", "Hotels_Id", "dbo.Hotels", "Id");
            AddForeignKey("dbo.Facilities", "Rooms_Id", "dbo.Rooms", "Id");
            DropColumn("dbo.Hotels", "Rooms_Id");
            DropColumn("dbo.Rooms", "Facilities_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Facilities_Id", c => c.Int());
            AddColumn("dbo.Hotels", "Rooms_Id", c => c.Int());
            DropForeignKey("dbo.Facilities", "Rooms_Id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "Hotels_Id", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "Hotels_Id" });
            DropIndex("dbo.Facilities", new[] { "Rooms_Id" });
            DropColumn("dbo.Facilities", "Rooms_Id");
            DropColumn("dbo.Rooms", "Hotels_Id");
            CreateIndex("dbo.Rooms", "Facilities_Id");
            CreateIndex("dbo.Hotels", "Rooms_Id");
            AddForeignKey("dbo.Hotels", "Rooms_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Rooms", "Facilities_Id", "dbo.Facilities", "Id");
        }
    }
}
