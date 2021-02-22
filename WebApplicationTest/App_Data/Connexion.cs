using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Connexion
    {
        private SqlConnection _con;
        private SqlDataAdapter _da;
        private string connectionPath = "Data Source=DESKTOP-L2O4DMO\\SQLEXPRESS;Initial Catalog=BDmusicOnLine;Integrated Security=True";
        public SqlConnection Con { get => _con; set => _con = value; }

        public Connexion()
        {
            _con = Con;
        }

        public void Connectdb_Get(string query, DataTable dt)
        {
            Con = new SqlConnection(connectionPath);
            _da = new SqlDataAdapter
            { 
                SelectCommand = new SqlCommand(query, Con)
            };
            _da.Fill(dt);
        }

        public void Connectdb(string query, SqlCommand cmd)
        {
            Con = new SqlConnection(connectionPath);
            cmd = new SqlCommand(query, Con);
            Con.Open();
        }
    }
}