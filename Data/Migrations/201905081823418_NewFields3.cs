namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFields3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "Checked", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserTasks", "Cheked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTasks", "Cheked", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserTasks", "Checked");
        }
    }
}
