namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionDeBanderaInteres : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "CalculateInterest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributions", "CalculateInterest");
        }
    }
}
