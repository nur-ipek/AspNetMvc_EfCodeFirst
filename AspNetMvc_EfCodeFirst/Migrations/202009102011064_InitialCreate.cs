namespace AspNetMvc_EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addres",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        AddressDefinition = c.String(maxLength: 300),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(nullable: false, maxLength: 20),
                        PersonSurname = c.String(nullable: false, maxLength: 20),
                        PersonAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addres", "Person_PersonId", "dbo.People");
            DropIndex("dbo.Addres", new[] { "Person_PersonId" });
            DropTable("dbo.People");
            DropTable("dbo.Addres");
        }
    }
}
