namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminacionGeneratedInterest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contributions", "GeneratedInterest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributions", "GeneratedInterest", c => c.Double(nullable: false));
        }
    }
}
