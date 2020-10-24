namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoNullaFornightenContrib : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contributions", "FortnightNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contributions", "FortnightNumber", c => c.Int(nullable: false));
        }
    }
}
