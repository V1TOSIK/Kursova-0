namespace Kursova.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserActivities", "Id", "dbo.UserDatas");
            DropForeignKey("dbo.UserHealths", "UserId", "dbo.UserDatas");
            DropIndex("dbo.UserActivities", new[] { "Id" });
            DropIndex("dbo.UserHealths", new[] { "UserId" });
            DropPrimaryKey("dbo.UserActivities");
            CreateTable(
                "dbo.UserDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDatas", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.UserActivities", "DateId", c => c.Int(nullable: false));
            AddColumn("dbo.UserHealths", "DateId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserActivities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserActivities", "Id");
            CreateIndex("dbo.UserActivities", "DateId");
            CreateIndex("dbo.UserHealths", "DateId");
            AddForeignKey("dbo.UserActivities", "DateId", "dbo.UserDates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserHealths", "DateId", "dbo.UserDates", "Id", cascadeDelete: true);
            DropColumn("dbo.UserActivities", "UserId");
            DropColumn("dbo.UserHealths", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserHealths", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.UserActivities", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserDates", "UserId", "dbo.UserDatas");
            DropForeignKey("dbo.UserHealths", "DateId", "dbo.UserDates");
            DropForeignKey("dbo.UserActivities", "DateId", "dbo.UserDates");
            DropIndex("dbo.UserHealths", new[] { "DateId" });
            DropIndex("dbo.UserDates", new[] { "UserId" });
            DropIndex("dbo.UserActivities", new[] { "DateId" });
            DropPrimaryKey("dbo.UserActivities");
            AlterColumn("dbo.UserActivities", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.UserHealths", "DateId");
            DropColumn("dbo.UserActivities", "DateId");
            DropTable("dbo.UserDates");
            AddPrimaryKey("dbo.UserActivities", "Id");
            CreateIndex("dbo.UserHealths", "UserId");
            CreateIndex("dbo.UserActivities", "Id");
            AddForeignKey("dbo.UserHealths", "UserId", "dbo.UserDatas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserActivities", "Id", "dbo.UserDatas", "Id");
        }
    }
}
