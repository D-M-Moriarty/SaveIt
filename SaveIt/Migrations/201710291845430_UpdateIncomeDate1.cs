namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIncomeDate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Incomes", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
