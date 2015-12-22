namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gr4wgw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.YuangongSets", "BumenSet_Id", "dbo.BumenSets");
            DropForeignKey("dbo.ShixiangSets", "YuangongSet_Id", "dbo.YuangongSets");
            DropIndex("dbo.YuangongSets", new[] { "BumenSet_Id" });
            DropIndex("dbo.ShixiangSets", new[] { "YuangongSet_Id" });
            RenameColumn(table: "dbo.YuangongSets", name: "BumenSet_Id", newName: "bumenId");
            RenameColumn(table: "dbo.ShixiangSets", name: "YuangongSet_Id", newName: "yuangongId");
            AlterColumn("dbo.YuangongSets", "bumenId", c => c.Long(nullable: false));
            AlterColumn("dbo.ShixiangSets", "yuangongId", c => c.Long(nullable: false));
            CreateIndex("dbo.YuangongSets", "bumenId");
            CreateIndex("dbo.ShixiangSets", "yuangongId");
            AddForeignKey("dbo.YuangongSets", "bumenId", "dbo.BumenSets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ShixiangSets", "yuangongId", "dbo.YuangongSets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShixiangSets", "yuangongId", "dbo.YuangongSets");
            DropForeignKey("dbo.YuangongSets", "bumenId", "dbo.BumenSets");
            DropIndex("dbo.ShixiangSets", new[] { "yuangongId" });
            DropIndex("dbo.YuangongSets", new[] { "bumenId" });
            AlterColumn("dbo.ShixiangSets", "yuangongId", c => c.Long());
            AlterColumn("dbo.YuangongSets", "bumenId", c => c.Long());
            RenameColumn(table: "dbo.ShixiangSets", name: "yuangongId", newName: "YuangongSet_Id");
            RenameColumn(table: "dbo.YuangongSets", name: "bumenId", newName: "BumenSet_Id");
            CreateIndex("dbo.ShixiangSets", "YuangongSet_Id");
            CreateIndex("dbo.YuangongSets", "BumenSet_Id");
            AddForeignKey("dbo.ShixiangSets", "YuangongSet_Id", "dbo.YuangongSets", "Id");
            AddForeignKey("dbo.YuangongSets", "BumenSet_Id", "dbo.BumenSets", "Id");
        }
    }
}
