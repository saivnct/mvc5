namespace Giangbb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerAge : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
        }
    }
}
