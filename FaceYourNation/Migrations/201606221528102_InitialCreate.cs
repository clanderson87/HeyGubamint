namespace FaceYourNation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        HouseID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        SenateID = c.String(),
                        PresidentialSupport = c.Boolean(nullable: false),
                        theBill = c.String(nullable: false),
                        Issue_Iid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.HouseID)
                .ForeignKey("dbo.Issues", t => t.Issue_Iid)
                .Index(t => t.Issue_Iid);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        vID = c.String(nullable: false, maxLength: 128),
                        District = c.String(nullable: false),
                        video_id = c.String(nullable: false),
                        issue_name = c.String(),
                        house_id = c.String(),
                        senate_id = c.String(),
                        support = c.String(),
                        importance = c.Int(nullable: false),
                        Bill_HouseID = c.String(maxLength: 128),
                        Issue_Iid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.vID)
                .ForeignKey("dbo.Bills", t => t.Bill_HouseID)
                .ForeignKey("dbo.Issues", t => t.Issue_Iid)
                .Index(t => t.Bill_HouseID)
                .Index(t => t.Issue_Iid);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Iid = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PresidentialPosition = c.String(),
                        PresPositionURL = c.String(),
                    })
                .PrimaryKey(t => t.Iid);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Votes", "Issue_Iid", "dbo.Issues");
            DropForeignKey("dbo.Bills", "Issue_Iid", "dbo.Issues");
            DropForeignKey("dbo.Votes", "Bill_HouseID", "dbo.Bills");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Votes", new[] { "Issue_Iid" });
            DropIndex("dbo.Votes", new[] { "Bill_HouseID" });
            DropIndex("dbo.Bills", new[] { "Issue_Iid" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Issues");
            DropTable("dbo.Votes");
            DropTable("dbo.Bills");
        }
    }
}
