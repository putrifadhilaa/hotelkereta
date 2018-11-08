namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelTest1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "Provinces_Id", "dbo.Provinces");
            DropIndex("dbo.Hotels", new[] { "Provinces_Id" });
            AddColumn("dbo.Hotels", "Villages_Id", c => c.Int());
            CreateIndex("dbo.Hotels", "Villages_Id");
            AddForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages", "Id");
            DropColumn("dbo.Hotels", "Provinces_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "Provinces_Id", c => c.Int());
            DropForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Hotels", new[] { "Villages_Id" });
            DropColumn("dbo.Hotels", "Villages_Id");
            CreateIndex("dbo.Hotels", "Provinces_Id");
            AddForeignKey("dbo.Hotels", "Provinces_Id", "dbo.Provinces", "Id");
        }
    }
}
