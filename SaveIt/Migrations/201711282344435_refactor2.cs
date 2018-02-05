namespace SaveIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expenses", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.Incomes", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.Expenses", new[] { "Budget_Id" });
            DropIndex("dbo.Incomes", new[] { "Budget_Id" });
            DropColumn("dbo.Expenses", "Budget_Id");
            DropColumn("dbo.Incomes", "Budget_Id");
            DropTable("dbo.Budgets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Incomes", "Budget_Id", c => c.Int());
            AddColumn("dbo.Expenses", "Budget_Id", c => c.Int());
            CreateIndex("dbo.Incomes", "Budget_Id");
            CreateIndex("dbo.Expenses", "Budget_Id");
            AddForeignKey("dbo.Incomes", "Budget_Id", "dbo.Budgets", "Id");
            AddForeignKey("dbo.Expenses", "Budget_Id", "dbo.Budgets", "Id");
        }
    }
}
