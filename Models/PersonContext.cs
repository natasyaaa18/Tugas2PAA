﻿using Npgsql;
using Tugas2PAA.Helpers;
using Tugas2PAA.Models;

namespace Tugas2PAA.Models
{
    public class PersonContext
    {
        private string __constr;
        private string __ErrorMsg;

        public PersonContext(string pConstr)
        {
            __constr = pConstr;
        }
        public List<Murid> ListPerson()
        {
            List<Murid> list1 = new List<Murid>();
            string query = string.Format(@"SELECT id_person, nama, alamat, email FROM users.person;");
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list1.Add(new Murid()
                    {
                        id_person = int.Parse(reader["id_person"].ToString()),
                        nama = reader["nama"].ToString(),
                        alamat = reader["alamat"].ToString(),
                        email = reader["email"].ToString()
                    });
                }
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
            return list1;

        }

        //create
        public void AddPerson(Murid person)
        {
            string query = string.Format(@"INSERT INTO users.person (nama, alamat, email) VALUES ('{0}', '{1}', '{2}');",
                person.nama, person.alamat, person.email);
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        //update
        public void UpdatePerson(Murid person)
        {
            string query = string.Format(@"UPDATE users.person SET nama = '{0}', alamat = '{1}', email = '{2}' WHERE id_person = {3};",
                person.nama, person.alamat, person.email, person.id_person);
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }

        //delete
        public void DeletePerson(int id)
        {
            string query = string.Format(@"DELETE FROM users.person WHERE id_person = {0};", id);
            SqlDBHelper db = new SqlDBHelper(this.__constr);
            try
            {
                NpgsqlCommand cmd = db.GetNpgsqlCommand(query);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                __ErrorMsg = ex.Message;
            }
        }



    }


}