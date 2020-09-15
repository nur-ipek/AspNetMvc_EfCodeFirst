using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetMvc_EfCodeFirst.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() {
            Database.SetInitializer(new DatabaseCreation()); 
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Addres> Addreses { get; set; }
    }
    public class DatabaseCreation: CreateDatabaseIfNotExists<DatabaseContext>
    {
   
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.PersonName = FakeData.NameData.GetMaleFirstName();
                person.PersonSurname = FakeData.NameData.GetFirstName();
                person.PersonAge = FakeData.NumberData.GetNumber(10, 50);

                context.People.Add(person);
            }
            context.SaveChanges();

            List<Person> people = context.People.ToList();

            foreach (var item in people)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Addres addres = new Addres();
                    addres.AddressDefinition = FakeData.PlaceData.GetAddress();
                    addres.Person = item;

                    context.Addreses.Add(addres);
                        

                }

                context.SaveChanges();
            }
        }

    }
}