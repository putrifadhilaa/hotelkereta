namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelqwerty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facilities",
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
            
            AddColumn("dbo.DetailHotels", "Facilities_Id", c => c.Int());
            CreateIndex("dbo.DetailHotels", "Facilities_Id");
            AddForeignKey("dbo.DetailHotels", "Facilities_Id", "dbo.Facilities", "Id");
            DropColumn("dbo.DetailHotels", "Facility");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DetailHotels", "Facility", c => c.String());
            DropForeignKey("dbo.DetailHotels", "Facilities_Id", "dbo.Facilities");
            DropIndex("dbo.DetailHotels", new[] { "Facilities_Id" });
            DropColumn("dbo.DetailHotels", "Facilities_Id");
            DropTable("dbo.Facilities");
        }
    }
}
