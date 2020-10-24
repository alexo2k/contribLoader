namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EliminarpropiedadCalculateInterest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contributions", "CalculateInterest");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributions", "CalculateInterest", c => c.Boolean(nullable: false));
        }
    }
}
