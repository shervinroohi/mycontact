using mycontact.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace mycontact.Services
{
    internal class ContactRepository : IContactRepository
    {
        private string strconection =
        ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public bool Delete(int contactid)
        {
            using (SqlConnection conection = new SqlConnection(strconection))
            {
                try
                {
                    string query = "Delete From mycontact where contactid=@id";
                    SqlCommand command = new SqlCommand(query, conection);
                    command.Parameters.AddWithValue("@id", contactid);
                    conection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
            using (SqlConnection conection = new SqlConnection(strconection))
            {
                try
                {
                    string query = "Insert Into mycontact (name,family,mobile,email,age,address) Values (@name,@family,@mobile,@email,@age,@address)";
                    SqlCommand command = new SqlCommand(query, conection);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@family", family);
                    command.Parameters.AddWithValue("@mobile", mobile);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@address", address);
                    conection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From mycontact Where name like @parameter Or family like @parameter";
            using (SqlConnection conection = new SqlConnection(strconection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
                adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }

        public DataTable GetAll()
        {
            string query = "Select * From mycontact";
            using (SqlConnection conection = new SqlConnection(strconection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }

        public DataTable GetById(int contactid)
        {
            string query = "Select * From mycontact Where contactid=@id";
            using (SqlConnection conection = new SqlConnection(strconection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", contactid);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }

        public bool Update(int contactid, string name, string family, string mobile, string email, int age, string address)
        {
            using (SqlConnection conection = new SqlConnection(strconection))
            {
                try
                {
                    string query = "Update mycontact set name=@name,family=@family,mobile=@mobile,email=@email,age=@age,address=@address Where contactid=@id";
                    SqlCommand command = new SqlCommand(query, conection);
                    command.Parameters.AddWithValue("@id", contactid);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@family", family);
                    command.Parameters.AddWithValue("@mobile", mobile);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@address", address);
                    conection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}