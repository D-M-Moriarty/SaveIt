namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIncomeDate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AsOfDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Budgets", "Month", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Budgets", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Budgets", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Expenses", "TransactionDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Expenses", "FirstGoOff", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Payees", "AsOfDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Intervals", "Until", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Incomes", "FirstGoOff", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Goals", "DesiredDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Goals", "DesiredDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Incomes", "FirstGoOff", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Intervals", "Until", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Payees", "AsOfDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Expenses", "FirstGoOff", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Expenses", "TransactionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Budgets", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Budgets", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Budgets", "Month", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Accounts", "AsOfDate", c => c.DateTime(nullable: false));
        }
    }
}
