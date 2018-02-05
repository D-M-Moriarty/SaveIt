namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "RecurrenceInterval_Id", "dbo.Intervals");
            DropForeignKey("dbo.Incomes", "RecurrenceInterval_Id", "dbo.Intervals");
            DropIndex("dbo.Expenses", new[] { "RecurrenceInterval_Id" });
            DropIndex("dbo.Incomes", new[] { "RecurrenceInterval_Id" });
            DropColumn("dbo.Expenses", "IsRecurring");
            DropColumn("dbo.Expenses", "FirstGoOff");
            DropColumn("dbo.Expenses", "RecurrenceInterval_Id");
            DropColumn("dbo.Incomes", "IsRecurring");
            DropColumn("dbo.Incomes", "FirstGoOff");
            DropColumn("dbo.Incomes", "RecurrenceInterval_Id");
            DropTable("dbo.Intervals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Intervals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntervalTime = c.String(),
                        Until = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Incomes", "RecurrenceInterval_Id", c => c.Int());
            AddColumn("dbo.Incomes", "FirstGoOff", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Incomes", "IsRecurring", c => c.Boolean(nullable: false));
            AddColumn("dbo.Expenses", "RecurrenceInterval_Id", c => c.Int());
            AddColumn("dbo.Expenses", "FirstGoOff", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Expenses", "IsRecurring", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Incomes", "RecurrenceInterval_Id");
            CreateIndex("dbo.Expenses", "RecurrenceInterval_Id");
            AddForeignKey("dbo.Incomes", "RecurrenceInterval_Id", "dbo.Intervals", "Id");
            AddForeignKey("dbo.Expenses", "RecurrenceInterval_Id", "dbo.Intervals", "Id");
        }
    }
}
