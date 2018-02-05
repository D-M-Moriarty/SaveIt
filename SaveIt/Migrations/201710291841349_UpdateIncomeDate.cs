namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIncomeDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false));
        }
    }
}
