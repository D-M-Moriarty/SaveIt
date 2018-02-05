namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        InitialBalance = c.Double(nullable: false),
                        AsOfDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        IsRecurring = c.Boolean(nullable: false),
                        FirstGoOff = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Payee_Id = c.Int(),
                        RecurrenceInterval_Id = c.Int(),
                        Budget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Payees", t => t.Payee_Id)
                .ForeignKey("dbo.Intervals", t => t.RecurrenceInterval_Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Payee_Id)
                .Index(t => t.RecurrenceInterval_Id)
                .Index(t => t.Budget_Id);
            
            CreateTable(
                "dbo.Payees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Telephone = c.String(),
                        Address = c.String(),
                        AsOfDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Intervals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntervalTime = c.String(),
                        Until = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                        IsRecurring = c.Boolean(nullable: false),
                        FirstGoOff = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Payer_Id = c.Int(),
                        RecurrenceInterval_Id = c.Int(),
                        Budget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Payees", t => t.Payer_Id)
                .ForeignKey("dbo.Intervals", t => t.RecurrenceInterval_Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Payer_Id)
                .Index(t => t.RecurrenceInterval_Id)
                .Index(t => t.Budget_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Budget = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TargetAmount = c.Double(nullable: false),
                        SavedAlready = c.Double(nullable: false),
                        DesiredDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Incomes", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.Incomes", "RecurrenceInterval_Id", "dbo.Intervals");
            DropForeignKey("dbo.Incomes", "Payer_Id", "dbo.Payees");
            DropForeignKey("dbo.Incomes", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Expenses", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.Expenses", "RecurrenceInterval_Id", "dbo.Intervals");
            DropForeignKey("dbo.Expenses", "Payee_Id", "dbo.Payees");
            DropForeignKey("dbo.Expenses", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Incomes", new[] { "Budget_Id" });
            DropIndex("dbo.Incomes", new[] { "RecurrenceInterval_Id" });
            DropIndex("dbo.Incomes", new[] { "Payer_Id" });
            DropIndex("dbo.Incomes", new[] { "Account_Id" });
            DropIndex("dbo.Expenses", new[] { "Budget_Id" });
            DropIndex("dbo.Expenses", new[] { "RecurrenceInterval_Id" });
            DropIndex("dbo.Expenses", new[] { "Payee_Id" });
            DropIndex("dbo.Expenses", new[] { "Account_Id" });
            DropTable("dbo.Goals");
            DropTable("dbo.Categories");
            DropTable("dbo.Incomes");
            DropTable("dbo.Intervals");
            DropTable("dbo.Payees");
            DropTable("dbo.Expenses");
            DropTable("dbo.Budgets");
            DropTable("dbo.Accounts");
        }
    }
}
