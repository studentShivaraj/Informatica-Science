namespace IndproCareer.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indpro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admissions",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        AdharNo = c.String(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Email = c.String(),
                        School = c.String(nullable: false),
                        Nationality = c.Int(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Pincode = c.Int(nullable: false),
                        PassingYear = c.String(nullable: false),
                        TotalMarks = c.Int(nullable: false),
                        SecuredMark = c.Int(nullable: false),
                        Percentage = c.Single(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        Agree = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.BasicDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Email = c.String(),
                        DOB = c.DateTime(nullable: false),
                        MobileNo = c.String(),
                        AdharNo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        CId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.Colleges", t => t.CId, cascadeDelete: true)
                .Index(t => t.CId);
            
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        YOE = c.Int(nullable: false),
                        Email = c.String(),
                        Contact = c.String(nullable: false, maxLength: 10),
                        City = c.String(),
                        Pincode = c.Int(nullable: false),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.CId)
                .ForeignKey("dbo.Universities", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SId = c.Int(nullable: false, identity: true),
                        CId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        YOE = c.Int(nullable: false),
                        Email = c.String(),
                        Contact = c.String(nullable: false, maxLength: 10),
                        City = c.String(),
                        Pincode = c.Int(nullable: false),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.SId)
                .ForeignKey("dbo.Colleges", t => t.CId, cascadeDelete: true)
                .Index(t => t.CId);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        YOE = c.Int(nullable: false),
                        Slogan = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Citis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitiName = c.String(nullable: false),
                        States_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.States_Id)
                .Index(t => t.States_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false),
                        Countrys_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Countrys_Id)
                .Index(t => t.Countrys_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountyName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassNo = c.Int(nullable: false, identity: true),
                        SId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Madium = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClassNo)
                .ForeignKey("dbo.Schools", t => t.SId, cascadeDelete: true)
                .Index(t => t.SId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Pincode = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SendMails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        To = c.String(nullable: false),
                        Subject = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RoleName = c.String(),
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
                        UserId = c.Int(nullable: false),
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Visiters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Comments = c.String(nullable: false, maxLength: 200),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Classes", "SId", "dbo.Schools");
            DropForeignKey("dbo.Citis", "States_Id", "dbo.States");
            DropForeignKey("dbo.States", "Countrys_Id", "dbo.Countries");
            DropForeignKey("dbo.Branches", "CId", "dbo.Colleges");
            DropForeignKey("dbo.Colleges", "Id", "dbo.Universities");
            DropForeignKey("dbo.Schools", "CId", "dbo.Colleges");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Classes", new[] { "SId" });
            DropIndex("dbo.States", new[] { "Countrys_Id" });
            DropIndex("dbo.Citis", new[] { "States_Id" });
            DropIndex("dbo.Schools", new[] { "CId" });
            DropIndex("dbo.Colleges", new[] { "Id" });
            DropIndex("dbo.Branches", new[] { "CId" });
            DropTable("dbo.Visiters");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SendMails");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Registers");
            DropTable("dbo.Languages");
            DropTable("dbo.Classes");
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Citis");
            DropTable("dbo.Universities");
            DropTable("dbo.Schools");
            DropTable("dbo.Colleges");
            DropTable("dbo.Branches");
            DropTable("dbo.BasicDetails");
            DropTable("dbo.Admissions");
        }
    }
}
