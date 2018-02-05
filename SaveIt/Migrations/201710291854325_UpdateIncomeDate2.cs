namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIncomeDate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false));
        }
    }
}
