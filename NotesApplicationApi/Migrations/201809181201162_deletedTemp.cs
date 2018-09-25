namespace NotesApplicationApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedTemp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Weather", "temp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weather", "temp", c => c.String(maxLength: 100));
        }
    }
}
