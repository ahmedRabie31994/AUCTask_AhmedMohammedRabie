namespace AUCTechnicalTask_AhmedMohammedRabie.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMessageToApply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForScholarships", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForScholarships", "Message");
        }
    }
}
