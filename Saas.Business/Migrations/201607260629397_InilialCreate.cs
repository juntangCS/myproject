namespace Saas.Business.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InilialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        FullName = c.String(unicode: false),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                        LastUpdatedTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
