namespace SntsepomexContributionLoader.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        ContributionId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FortnightNumber = c.Int(nullable: false),
                        Year = c.String(maxLength: 4),
                        ContributionBalance = c.Double(nullable: false),
                        ContributionAccumulated = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ContributionId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(maxLength: 6),
                        LastName = c.String(maxLength: 40),
                        MaidenName = c.String(maxLength: 40),
                        Name = c.String(maxLength: 60),
                        RFC = c.String(maxLength: 13),
                        CURP = c.String(maxLength: 18),
                        GovernmentEntry = c.DateTime(nullable: false),
                        DependencyEntry = c.DateTime(nullable: false),
                        WorkplaceId = c.Int(nullable: false),
                        WorkPositionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Workplaces", t => t.WorkplaceId, cascadeDelete: true)
                .ForeignKey("dbo.WorkPositions", t => t.WorkPositionId, cascadeDelete: true)
                .Index(t => t.WorkplaceId)
                .Index(t => t.WorkPositionId);
            
            CreateTable(
                "dbo.Workplaces",
                c => new
                    {
                        WorkplaceId = c.Int(nullable: false, identity: true),
                        WorkplaceCode = c.String(maxLength: 11),
                        WorkplaceDescription = c.String(),
                        WorkplaceCity = c.String(maxLength: 3),
                        WorkplaceZone = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.WorkplaceId);
            
            CreateTable(
                "dbo.WorkPositions",
                c => new
                    {
                        WorkPositionId = c.Int(nullable: false, identity: true),
                        WorkPositionCode = c.String(maxLength: 7),
                        WorkPositionLevel = c.String(maxLength: 3),
                        WorkPositionDescription = c.String(),
                        WorkPositionType = c.String(),
                    })
                .PrimaryKey(t => t.WorkPositionId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        InterestId = c.Int(nullable: false, identity: true),
                        Year = c.String(maxLength: 4),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InterestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "WorkPositionId", "dbo.WorkPositions");
            DropForeignKey("dbo.Employees", "WorkplaceId", "dbo.Workplaces");
            DropForeignKey("dbo.Contributions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "WorkPositionId" });
            DropIndex("dbo.Employees", new[] { "WorkplaceId" });
            DropIndex("dbo.Contributions", new[] { "EmployeeId" });
            DropTable("dbo.Interests");
            DropTable("dbo.WorkPositions");
            DropTable("dbo.Workplaces");
            DropTable("dbo.Employees");
            DropTable("dbo.Contributions");
        }
    }
}
