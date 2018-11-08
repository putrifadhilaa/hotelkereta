namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelabcd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regencies", "Villages_Id", "dbo.Villages");
            DropForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies");
            DropForeignKey("dbo.Provinces", "Districts_Id", "dbo.Districts");
            DropIndex("dbo.Districts", new[] { "Regencies_Id" });
            DropIndex("dbo.Regencies", new[] { "Villages_Id" });
            DropIndex("dbo.Provinces", new[] { "Districts_Id" });
            AddColumn("dbo.Districts", "Provinces_Id", c => c.Int());
            AddColumn("dbo.Regencies", "Districts_Id", c => c.Int());
            AddColumn("dbo.Villages", "Regencies_Id", c => c.Int());
            CreateIndex("dbo.Districts", "Provinces_Id");
            CreateIndex("dbo.Villages", "Regencies_Id");
            CreateIndex("dbo.Regencies", "Districts_Id");
            AddForeignKey("dbo.Districts", "Provinces_Id", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Regencies", "Districts_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.Villages", "Regencies_Id", "dbo.Regencies", "Id");
            DropColumn("dbo.Districts", "Regencies_Id");
            DropColumn("dbo.Regencies", "Villages_Id");
            DropColumn("dbo.Provinces", "Districts_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provinces", "Districts_Id", c => c.Int());
            AddColumn("dbo.Regencies", "Villages_Id", c => c.Int());
            AddColumn("dbo.Districts", "Regencies_Id", c => c.Int());
            DropForeignKey("dbo.Villages", "Regencies_Id", "dbo.Regencies");
            DropForeignKey("dbo.Regencies", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Districts", "Provinces_Id", "dbo.Provinces");
            DropIndex("dbo.Regencies", new[] { "Districts_Id" });
            DropIndex("dbo.Villages", new[] { "Regencies_Id" });
            DropIndex("dbo.Districts", new[] { "Provinces_Id" });
            DropColumn("dbo.Villages", "Regencies_Id");
            DropColumn("dbo.Regencies", "Districts_Id");
            DropColumn("dbo.Districts", "Provinces_Id");
            CreateIndex("dbo.Provinces", "Districts_Id");
            CreateIndex("dbo.Regencies", "Villages_Id");
            CreateIndex("dbo.Districts", "Regencies_Id");
            AddForeignKey("dbo.Provinces", "Districts_Id", "dbo.Districts", "Id");
            AddForeignKey("dbo.Districts", "Regencies_Id", "dbo.Regencies", "Id");
            AddForeignKey("dbo.Regencies", "Villages_Id", "dbo.Villages", "Id");
        }
    }
}
