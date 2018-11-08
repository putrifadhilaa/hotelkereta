namespace TugasPutriEri.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelTest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetailHotels", "Facility", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetailHotels", "Facility");
        }
    }
}
