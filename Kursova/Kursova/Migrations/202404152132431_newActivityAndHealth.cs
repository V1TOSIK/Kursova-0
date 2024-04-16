namespace Kursova.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newActivityAndHealth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserHealths", "Pulse", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserHealths", "Pulse", c => c.String());
        }
    }
}
