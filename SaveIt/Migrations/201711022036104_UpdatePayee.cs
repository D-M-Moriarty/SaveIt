namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payees", "IsPayee", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payees", "IsPayee");
        }
    }
}
