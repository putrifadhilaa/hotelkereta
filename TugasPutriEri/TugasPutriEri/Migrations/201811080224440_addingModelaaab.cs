namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelaaab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facilities", "Rooms_Id", "dbo.Rooms");
            DropIndex("dbo.Facilities", new[] { "Rooms_Id" });
            DropColumn("dbo.Facilities", "Rooms_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facilities", "Rooms_Id", c => c.Int());
            CreateIndex("dbo.Facilities", "Rooms_Id");
            AddForeignKey("dbo.Facilities", "Rooms_Id", "dbo.Rooms", "Id");
        }
    }
}
