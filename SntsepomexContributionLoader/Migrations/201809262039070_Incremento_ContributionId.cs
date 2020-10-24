namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Incremento_ContributionId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Contributions");
            AlterColumn("dbo.Contributions", "ContributionId", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contributions", "ContributionId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Contributions");
            AlterColumn("dbo.Contributions", "ContributionId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contributions", "ContributionId");
        }
    }
}
