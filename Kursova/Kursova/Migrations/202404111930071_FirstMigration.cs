namespace Kursova.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ExerciseName = c.String(),
                        ConsumedCalories = c.Double(nullable: false),
                        BurnedCalories = c.Double(nullable: false),
                        Steps = c.Int(nullable: false),
                        Traveled = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDatas", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserHealths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pulse = c.String(),
                        Pressure = c.String(),
                        VolumeOxygenInBlood = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDatas", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserHealths", "UserId", "dbo.UserDatas");
            DropForeignKey("dbo.UserActivities", "Id", "dbo.UserDatas");
            DropIndex("dbo.UserHealths", new[] { "UserId" });
            DropIndex("dbo.UserActivities", new[] { "Id" });
            DropTable("dbo.UserHealths");
            DropTable("dbo.UserDatas");
            DropTable("dbo.UserActivities");
        }
    }
}
