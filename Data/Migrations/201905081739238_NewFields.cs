namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "LastUpdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserTasks", "Cheked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTasks", "Cheked");
            DropColumn("dbo.UserTasks", "LastUpdate");
        }
    }
}
