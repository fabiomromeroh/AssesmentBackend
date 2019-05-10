namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFields2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserTasks", "LastUpdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserTasks", "LastUpdate", c => c.DateTime(nullable: false));
        }
    }
}
