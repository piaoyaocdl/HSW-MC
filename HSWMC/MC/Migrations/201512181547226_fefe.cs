namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fefe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BumenSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        bumenmingcheng = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BumenSets");
        }
    }
}
