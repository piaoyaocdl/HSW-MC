namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fefw : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShixiangjinduSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        shijian = c.DateTime(),
                        jindu = c.String(),
                        ShixiangSet_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShixiangSets", t => t.ShixiangSet_Id)
                .Index(t => t.ShixiangSet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShixiangjinduSets", "ShixiangSet_Id", "dbo.ShixiangSets");
            DropIndex("dbo.ShixiangjinduSets", new[] { "ShixiangSet_Id" });
            DropTable("dbo.ShixiangjinduSets");
        }
    }
}
