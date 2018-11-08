namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelTest3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
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
            
            AddColumn("dbo.DetailHotels", "Rooms_Id", c => c.Int());
            CreateIndex("dbo.DetailHotels", "Rooms_Id");
            AddForeignKey("dbo.DetailHotels", "Rooms_Id", "dbo.Rooms", "Id");
            DropColumn("dbo.DetailHotels", "Room");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetailHotels", "Room", c => c.String());
            DropForeignKey("dbo.DetailHotels", "Rooms_Id", "dbo.Rooms");
            DropIndex("dbo.DetailHotels", new[] { "Rooms_Id" });
            DropColumn("dbo.DetailHotels", "Rooms_Id");
            DropTable("dbo.Rooms");
        }
    }
}
