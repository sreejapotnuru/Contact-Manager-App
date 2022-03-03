namespace ContactsApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.ContactViewModels",
                c => new
                    {
                        ContactKey = c.Int(nullable: false, identity: true),
                        contact_ContactID = c.Int(),
                    })
                .PrimaryKey(t => t.ContactKey)
                .ForeignKey("dbo.Contacts", t => t.contact_ContactID)
                .Index(t => t.contact_ContactID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                        Secret = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactViewModels", "contact_ContactID", "dbo.Contacts");
            DropIndex("dbo.ContactViewModels", new[] { "contact_ContactID" });
            DropTable("dbo.Users");
            DropTable("dbo.ContactViewModels");
            DropTable("dbo.Contacts");
        }
    }
}
