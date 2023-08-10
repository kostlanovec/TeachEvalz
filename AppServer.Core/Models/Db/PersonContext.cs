using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppServer.Core.Models.Db
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options)
        : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=..\\AppServer.Core\\person.db");
        }
        public DbSet<Person> Persons {  get; set; }
    }
}
