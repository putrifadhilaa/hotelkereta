namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelAbcdef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Hotels", new[] { "Villages_Id" });
            AddColumn("dbo.Hotels", "Districts_Id", c => c.Int());
            CreateIndex("dbo.Hotels", "Districts_Id");
            AddForeignKey("dbo.Hotels", "Districts_Id", "dbo.Districts", "Id");
            DropColumn("dbo.Hotels", "Villages_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hotels", "Villages_Id", c => c.Int());
            DropForeignKey("dbo.Hotels", "Districts_Id", "dbo.Districts");
            DropIndex("dbo.Hotels", new[] { "Districts_Id" });
            DropColumn("dbo.Hotels", "Districts_Id");
            CreateIndex("dbo.Hotels", "Villages_Id");
            AddForeignKey("dbo.Hotels", "Villages_Id", "dbo.Villages", "Id");
        }
    }
}
