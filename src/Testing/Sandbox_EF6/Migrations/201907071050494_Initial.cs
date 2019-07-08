namespace Sandbox_EF6
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PressReleaseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PressReleasePressReleaseDetails_Id = c.Int(name: "PressRelease.PressReleaseDetails_Id", nullable: false),
                        PressRelease_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PressReleases", t => t.PressReleasePressReleaseDetails_Id, cascadeDelete: true)
                .ForeignKey("dbo.PressReleases", t => t.PressRelease_Id, cascadeDelete: true)
                .Index(t => t.PressReleasePressReleaseDetails_Id)
                .Index(t => t.PressRelease_Id);
            
            CreateTable(
                "dbo.PressReleases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PressReleaseDetails", "PressRelease_Id", "dbo.PressReleases");
            DropForeignKey("dbo.PressReleaseDetails", "PressRelease.PressReleaseDetails_Id", "dbo.PressReleases");
            DropIndex("dbo.PressReleaseDetails", new[] { "PressRelease_Id" });
            DropIndex("dbo.PressReleaseDetails", new[] { "PressRelease.PressReleaseDetails_Id" });
            DropTable("dbo.PressReleases");
            DropTable("dbo.PressReleaseDetails");
        }
    }
}