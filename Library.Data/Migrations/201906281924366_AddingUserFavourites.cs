namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserFavourites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFavourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFavourites", "BookId", "dbo.Books");
            DropIndex("dbo.UserFavourites", new[] { "BookId" });
            DropTable("dbo.UserFavourites");
        }
    }
}
