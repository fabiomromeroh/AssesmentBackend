namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "UserID", "dbo.Users");
            DropIndex("dbo.UserTasks", new[] { "UserID" });
            DropTable("dbo.UserTasks");
            DropTable("dbo.Users");
        }
    }
}
