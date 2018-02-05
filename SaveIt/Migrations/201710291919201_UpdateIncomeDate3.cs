namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIncomeDate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime());
        }
    }
}
