 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationTest.Models;

namespace WebApplicationTest.Controllers
{
    public class UserController : ApiController
    {
        Connexion conn = new Connexion();

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from User", _dt);
            List<User> users = new List<User>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow UserRecord in _dt.Rows)
                {
                    users.Add(new ReadUser(UserRecord));
                }
            }
            return users;
        }


        //GET: api/User/5
        [Route("api/User/{id}")]
        [HttpGet]
        public IEnumerable<User> Get(int id)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from User where Id_user='" + id + "'", _dt);
            List<User> users = new List<User>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow UserRecord in _dt.Rows)
                {
                    users.Add(new ReadUser(UserRecord));
                }
            }
            return users;
        }


        // POST: api/User
        public string Post([FromBody]CreateUser value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into User(Id_user, Name_user, Email_user, Password_user)values(@Id_user, @Name_user, @Email_user, @Password_user)", cmd);
            cmd.Parameters.AddWithValue("@Id_user", value.Id_user);
            cmd.Parameters.AddWithValue("@Name_user", value.Name_user);
            cmd.Parameters.AddWithValue("@Email_user", value.Email_user);
            cmd.Parameters.AddWithValue("@Password_user", value.Password_user);
            conn.Con.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "insertion réussie";
            }
            else
            {
                return "echec insertion";
            }
        }


        // PUT: api/User/5
        public string Put(int id, [FromBody]CreateUser value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update User set Name_user=@Name_user, Email_user=@Email_user, Password_user=@Password_user where Id_user='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Name_user", value.Name_user);
            cmd.Parameters.AddWithValue("@Email_user", value.Email_user);
            cmd.Parameters.AddWithValue("@Password_user", value.Password_user);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "mise à jour réussie";
            }
            else
            {
                return "echec mise à jour";
            }
        }

        // DELETE: api/User/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from User where Id_user='" + id + "'", cmd);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "suppression réussie";
            }
            else
            {
                return "echec suppression";
            }
        }
    }
}
