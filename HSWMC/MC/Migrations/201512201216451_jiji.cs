namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jiji : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShixiangSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        shixiang = c.String(),
                        beizhu = c.String(),
                        YuangongSet_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.YuangongSets", t => t.YuangongSet_Id)
                .Index(t => t.YuangongSet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShixiangSets", "YuangongSet_Id", "dbo.YuangongSets");
            DropIndex("dbo.ShixiangSets", new[] { "YuangongSet_Id" });
            DropTable("dbo.ShixiangSets");
        }
    }
}
