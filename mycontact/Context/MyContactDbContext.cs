using System.Data.Entity;
using mycontact.Models;

namespace mycontact.Context
{
    public class MyContactDbContext : DbContext
    {
        public MyContactDbContext()
            : base("MyConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}