namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Hotels", new[] { "Villages_Id" });
            AddColumn("dbo.Hotels", "Provinces_Id", c => c.Int());
            CreateIndex("dbo.Hotels", "Provinces_Id");
            AddForeignKey("dbo.Hotels", "Provinces_Id", "dbo.Provinces", "Id");
            DropColumn("dbo.DetailHotels", "Facility");
            DropColumn("dbo.Hotels", "Villages_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "Villages_Id", c => c.Int());
            AddColumn("dbo.DetailHotels", "Facility", c => c.String());
            DropForeignKey("dbo.Hotels", "Provinces_Id", "dbo.Provinces");
            DropIndex("dbo.Hotels", new[] { "Provinces_Id" });
            DropColumn("dbo.Hotels", "Provinces_Id");
            CreateIndex("dbo.Hotels", "Villages_Id");
            AddForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages", "Id");
        }
    }
}
