namespace FaceYourNation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Take19 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Votes");
            AddColumn("dbo.Votes", "VoteId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Votes", "VoteId");
            DropColumn("dbo.Votes", "vID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Votes", "vID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Votes");
            DropColumn("dbo.Votes", "VoteId");
            AddPrimaryKey("dbo.Votes", "vID");
        }
    }
}
