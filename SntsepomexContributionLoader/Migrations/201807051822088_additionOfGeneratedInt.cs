namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionOfGeneratedInt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "GeneratedInterest", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributions", "GeneratedInterest");
        }
    }
}
