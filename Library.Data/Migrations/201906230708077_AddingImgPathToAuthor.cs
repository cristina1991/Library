namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingImgPathToAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "ImgPath", c => c.String(nullable:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "ImgPath");
        }
    }
}
