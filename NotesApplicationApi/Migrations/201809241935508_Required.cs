namespace NotesApplicationApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weather", "Notes", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weather", "Notes", c => c.String());
        }
    }
}
