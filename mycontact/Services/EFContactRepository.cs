using mycontact.Context;
using mycontact.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace mycontact.Services
{
    internal class EFContactRepository
    {
       // MyContactDbContext db = new MyContactDbContext();

        public List<Contact> GetAll()
        {
            using (var db = new MyContactDbContext())
            {
                return db.Contacts.AsNoTracking().ToList();
            }
        }

        public bool Insert(Contact contact)
        {
            using (var db = new MyContactDbContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return true;
            }
        }

        public bool Update(Contact contact)
        {
            using (var db = new MyContactDbContext())
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new MyContactDbContext())
            {
                var contact = db.Contacts.Find(id);

                if (contact == null)
                    return false;

                db.Contacts.Remove(contact);
                db.SaveChanges();

                return true;
            }
        }

        public List<Contact> Search(string parameter)
        {
            using (var db = new MyContactDbContext())
            {
                return db.Contacts
                         .AsNoTracking()
                         .Where(c => c.name.Contains(parameter)
                                  || c.family.Contains(parameter))
                         .ToList();
            }
        }


        public Contact GetById(int id)
        {
            using (var db = new MyContactDbContext())
            {
                return db.Contacts.Find(id);
            }
        }
    }
}