namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfew : DbMigration
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
            
            CreateTable(
                "dbo.ShixiangSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        shixiang = c.String(),
                        beizhu = c.String(),
                        yiwanjie = c.Boolean(nullable: false),
                        YuangongSet_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.YuangongSets", t => t.YuangongSet_Id)
                .Index(t => t.YuangongSet_Id);
            
            CreateTable(
                "dbo.ShixiangjinduSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        shijian = c.DateTime(),
                        jindu = c.String(),
                        shixiangId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShixiangSets", t => t.shixiangId, cascadeDelete: true)
                .Index(t => t.shixiangId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YuangongSets", "BumenSet_Id", "dbo.BumenSets");
            DropForeignKey("dbo.ShixiangSets", "YuangongSet_Id", "dbo.YuangongSets");
            DropForeignKey("dbo.ShixiangjinduSets", "shixiangId", "dbo.ShixiangSets");
            DropIndex("dbo.ShixiangjinduSets", new[] { "shixiangId" });
            DropIndex("dbo.ShixiangSets", new[] { "YuangongSet_Id" });
            DropIndex("dbo.YuangongSets", new[] { "BumenSet_Id" });
            DropTable("dbo.ShixiangjinduSets");
            DropTable("dbo.ShixiangSets");
            DropTable("dbo.YuangongSets");
            DropTable("dbo.BumenSets");
        }
    }
}
