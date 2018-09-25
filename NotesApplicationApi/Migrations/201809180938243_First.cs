namespace NotesApplicationApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weather",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Notes = c.String(),
                        temp = c.String(maxLength: 100),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weather");
        }
    }
}
