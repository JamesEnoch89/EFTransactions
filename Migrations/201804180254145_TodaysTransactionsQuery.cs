namespace EFTransactions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodaysTransactionsQuery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankTranscations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(),
                        Action = c.String(),
                        AccountNumber = c.String(),
                        AmountChanged = c.Decimal(precision: 18, scale: 2),
                        NewAmount = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankTranscations");
        }
    }
}
