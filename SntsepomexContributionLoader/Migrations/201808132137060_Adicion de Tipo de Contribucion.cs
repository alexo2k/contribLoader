namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdiciondeTipodeContribucion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "ContribType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributions", "ContribType");
        }
    }
}
