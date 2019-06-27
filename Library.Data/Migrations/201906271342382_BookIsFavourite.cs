namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookIsFavourite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "IsFavourite", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "IsFavourite");
        }
    }
}
