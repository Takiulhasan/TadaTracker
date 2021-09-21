namespace TadaEntries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.Int(nullable: false),
                        Travel_Cost = c.Int(nullable: false),
                        Lunch_Cost = c.Int(nullable: false),
                        Instrument_Cost = c.Int(nullable: false),
                        Paid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee1");
        }
    }
}
