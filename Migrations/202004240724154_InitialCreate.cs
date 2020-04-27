namespace WebApplication10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        B_Id = c.Int(nullable: false, identity: true),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        C_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.B_Id)
                .ForeignKey("dbo.Campgrounds", t => t.C_Id, cascadeDelete: true)
                .Index(t => t.C_Id);
            
            CreateTable(
                "dbo.Campgrounds",
                c => new
                    {
                        C_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.C_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "C_Id", "dbo.Campgrounds");
            DropIndex("dbo.Bookings", new[] { "C_Id" });
            DropTable("dbo.Campgrounds");
            DropTable("dbo.Bookings");
        }
    }
}
