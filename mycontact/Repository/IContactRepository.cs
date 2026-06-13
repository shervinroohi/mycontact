using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace mycontact.Repository
{
    internal interface IContactRepository
    {
        DataTable GetAll();
        DataTable GetById(int contactid);
        bool Insert(string name, string family, string mobile, string email, int age, string address);
        DataTable Search(string parameter);
        bool Update(int contactid, string name, string family, string mobile, string email, int age, string address);
        bool Delete(int contactid);
    
    }
}
