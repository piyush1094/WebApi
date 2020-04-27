namespace WebApplication10.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Customers",
               c => new
               {
                   CustomerId = c.Int(nullable: false, identity: true),
                   Name = c.String(nullable: false),
                   Username = c.String(nullable: false),
                   Password = c.String(nullable: false),
                   Address = c.String(nullable: false),
                   State = c.String(nullable: false),
                   Country = c.String(nullable: false),
                   Phoneno = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.CustomerId);
        }
        
        public override void Down()
        {
        }
    }
}
