namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelabcd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Regencies", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Provinces", "Regencies_Id", "dbo.Regencies");
            DropIndex("dbo.Districts", new[] { "Villages_Id" });
            DropIndex("dbo.Provinces", new[] { "Regencies_Id" });
            DropIndex("dbo.Regencies", new[] { "Districts_Id" });
            AddColumn("dbo.Districts", "Regencies_Id", c => c.Int());
            AddColumn("dbo.Hotels", "Villages_Id", c => c.Int());
            AddColumn("dbo.Provinces", "Districts_Id", c => c.Int());
            AddColumn("dbo.Regencies", "Villages_Id", c => c.Int());
            CreateIndex("dbo.Districts", "Regencies_Id");
            CreateIndex("dbo.Regencies", "Villages_Id");
            CreateIndex("dbo.Hotels", "Villages_Id");
            CreateIndex("dbo.Provinces", "Districts_Id");
            AddForeignKey("dbo.Regencies", "Villages_Id", "dbo.Villages", "Id");
            AddForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies", "Id");
            AddForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages", "Id");
            AddForeignKey("dbo.Provinces", "Districts_Id", "dbo.Districts", "Id");
            DropColumn("dbo.Districts", "Villages_Id");
            DropColumn("dbo.Provinces", "Regencies_Id");
            DropColumn("dbo.Regencies", "Districts_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regencies", "Districts_Id", c => c.Int());
            AddColumn("dbo.Provinces", "Regencies_Id", c => c.Int());
            AddColumn("dbo.Districts", "Villages_Id", c => c.Int());
            DropForeignKey("dbo.Provinces", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies");
            DropForeignKey("dbo.Regencies", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Provinces", new[] { "Districts_Id" });
            DropIndex("dbo.Hotels", new[] { "Villages_Id" });
            DropIndex("dbo.Regencies", new[] { "Villages_Id" });
            DropIndex("dbo.Districts", new[] { "Regencies_Id" });
            DropColumn("dbo.Regencies", "Villages_Id");
            DropColumn("dbo.Provinces", "Districts_Id");
            DropColumn("dbo.Hotels", "Villages_Id");
            DropColumn("dbo.Districts", "Regencies_Id");
            CreateIndex("dbo.Regencies", "Districts_Id");
            CreateIndex("dbo.Provinces", "Regencies_Id");
            CreateIndex("dbo.Districts", "Villages_Id");
            AddForeignKey("dbo.Provinces", "Regencies_Id", "dbo.Regencies", "Id");
            AddForeignKey("dbo.Regencies", "Districts_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.Districts", "Villages_Id", "dbo.Villages", "Id");
        }
    }
}
