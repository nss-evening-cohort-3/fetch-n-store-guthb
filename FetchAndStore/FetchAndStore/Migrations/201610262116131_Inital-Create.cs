namespace FetchAndStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false),
                        StatusCode = c.String(nullable: false),
                        Method = c.String(nullable: false),
                        RequestTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResponseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Responses");
        }
    }
}
