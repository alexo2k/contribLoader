namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiotamaniocampos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Employees", "RFC", c => c.String(maxLength: 15));
            AlterColumn("dbo.Employees", "CURP", c => c.String(maxLength: 22));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "CURP", c => c.String(maxLength: 18));
            AlterColumn("dbo.Employees", "RFC", c => c.String(maxLength: 13));
            AlterColumn("dbo.Employees", "EmployeeCode", c => c.String(maxLength: 6));
        }
    }
}
