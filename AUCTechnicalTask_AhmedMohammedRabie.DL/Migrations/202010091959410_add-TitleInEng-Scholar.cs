namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTitleInEngScholar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.scholarships", "TitleInEnglish", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.scholarships", "TitleInEnglish");
        }
    }
}
