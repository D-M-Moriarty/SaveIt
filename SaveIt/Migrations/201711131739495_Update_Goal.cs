namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Goal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goals", "GoalIsReached", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goals", "GoalIsReached");
        }
    }
}
