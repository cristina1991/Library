namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreAuthorLink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthorBookLinks", "AuthorId", "dbo.Genres");
            AddForeignKey("dbo.AuthorBookLinks", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorBookLinks", "AuthorId", "dbo.Authors");
            AddForeignKey("dbo.AuthorBookLinks", "AuthorId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
