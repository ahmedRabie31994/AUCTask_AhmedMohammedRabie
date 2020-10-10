namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPersonalInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "NationalId", c => c.String(nullable: false, maxLength: 14));
            AddColumn("dbo.AspNetUsers", "University", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Major", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "GPA", c => c.Single(nullable: false));
            AddColumn("dbo.AspNetUsers", "ResumeLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ResumeLink");
            DropColumn("dbo.AspNetUsers", "GPA");
            DropColumn("dbo.AspNetUsers", "Major");
            DropColumn("dbo.AspNetUsers", "University");
            DropColumn("dbo.AspNetUsers", "NationalId");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
