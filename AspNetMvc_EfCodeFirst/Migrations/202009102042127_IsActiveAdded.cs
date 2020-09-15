namespace AspNetMvc_EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsActiveAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addres", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "IsActive");
            DropColumn("dbo.Addres", "IsActive");
        }
    }
}
