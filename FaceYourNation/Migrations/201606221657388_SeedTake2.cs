namespace FaceYourNation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTake2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "Bill_HouseID", "dbo.Bills");
            DropIndex("dbo.Votes", new[] { "Bill_HouseID" });
            RenameColumn(table: "dbo.Votes", name: "Bill_HouseID", newName: "Bill_Bid");
            DropPrimaryKey("dbo.Bills");
            AddColumn("dbo.Bills", "Bid", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Bills", "HouseID", c => c.String());
            AlterColumn("dbo.Bills", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Votes", "Bill_Bid", c => c.Int());
            AddPrimaryKey("dbo.Bills", "Bid");
            CreateIndex("dbo.Votes", "Bill_Bid");
            AddForeignKey("dbo.Votes", "Bill_Bid", "dbo.Bills", "Bid");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Bill_Bid", "dbo.Bills");
            DropIndex("dbo.Votes", new[] { "Bill_Bid" });
            DropPrimaryKey("dbo.Bills");
            AlterColumn("dbo.Votes", "Bill_Bid", c => c.String(maxLength: 128));
            AlterColumn("dbo.Bills", "Name", c => c.String());
            AlterColumn("dbo.Bills", "HouseID", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Bills", "Bid");
            AddPrimaryKey("dbo.Bills", "HouseID");
            RenameColumn(table: "dbo.Votes", name: "Bill_Bid", newName: "Bill_HouseID");
            CreateIndex("dbo.Votes", "Bill_HouseID");
            AddForeignKey("dbo.Votes", "Bill_HouseID", "dbo.Bills", "HouseID");
        }
    }
}
