namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificacionContribucion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "ContributionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributions", "ContributionDate");
        }
    }
}
