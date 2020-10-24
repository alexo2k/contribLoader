namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificaciontamanioappaternoa100 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 40));
        }
    }
}
