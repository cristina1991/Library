namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableFavourite : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "IsFavourite", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "IsFavourite", c => c.Boolean(nullable: false));
        }
    }
}
