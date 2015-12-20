namespace MC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kokoko : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShixiangSets", "yiwanjie", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShixiangSets", "yiwanjie");
        }
    }
}
