namespace AspNetMvc_EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPersonId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addres", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Addres", new[] { "Person_PersonId" });
            RenameColumn(table: "dbo.Addres", name: "Person_PersonId", newName: "PersonId");
            AlterColumn("dbo.Addres", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addres", "PersonId");
            AddForeignKey("dbo.Addres", "PersonId", "dbo.People", "PersonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addres", "PersonId", "dbo.People");
            DropIndex("dbo.Addres", new[] { "PersonId" });
            AlterColumn("dbo.Addres", "PersonId", c => c.Int());
            RenameColumn(table: "dbo.Addres", name: "PersonId", newName: "Person_PersonId");
            CreateIndex("dbo.Addres", "Person_PersonId");
            AddForeignKey("dbo.Addres", "Person_PersonId", "dbo.People", "PersonId");
        }
    }
}
