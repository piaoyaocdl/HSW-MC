namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YuangongSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        yuangongmingzi = c.String(),
                        BumenSet_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BumenSets", t => t.BumenSet_Id)
                .Index(t => t.BumenSet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YuangongSets", "BumenSet_Id", "dbo.BumenSets");
            DropIndex("dbo.YuangongSets", new[] { "BumenSet_Id" });
            DropTable("dbo.YuangongSets");
        }
    }
}
