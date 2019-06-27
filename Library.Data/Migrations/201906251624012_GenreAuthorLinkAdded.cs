namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreAuthorLinkAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreAuthorLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenreAuthorLinks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.GenreAuthorLinks", "AuthorId", "dbo.Authors");
            DropIndex("dbo.GenreAuthorLinks", new[] { "AuthorId" });
            DropIndex("dbo.GenreAuthorLinks", new[] { "GenreId" });
            DropTable("dbo.GenreAuthorLinks");
        }
    }
}
