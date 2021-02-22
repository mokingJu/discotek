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
    public class SessionController : ApiController
    {
        Connexion conn = new Connexion();

        // GET: api/Session
        [HttpGet]
        public IEnumerable<Session> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Session", _dt);
            List<Session> sessions = new List<Session>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow sessionRecord in _dt.Rows)
                {
                    sessions.Add(new ReadSession(sessionRecord));
                }
            }
            return sessions;
        }


        // GET: api/Session/5
        [Route("api/Session/{id}")]
        [HttpGet]
        public IEnumerable<Session> Get(int id)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Session where Id_session='" + id + "'", _dt);
            List<Session> sessions = new List<Session>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow sessionRecord in _dt.Rows)
                {
                    sessions.Add(new ReadSession(sessionRecord));
                }
            }
            return sessions;
        }


        // POST: api/Session
        public string Post([FromBody]CreateSession value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into Session(Id_session, Id_user, Date_session, Duration_session)values(@Id_session, @Id_user, @Date_session, @Duration_session)", cmd);
            cmd.Parameters.AddWithValue("@Id_session", value.Id_session);   //auto-incrementé
            cmd.Parameters.AddWithValue("@Id_user", value.Id_user);
            cmd.Parameters.AddWithValue("@Date_session", value.Date_session);
            cmd.Parameters.AddWithValue("@Duration_session", value.Duration_session);
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


        // PUT: api/Session/5
        public string Put(int id, [FromBody]CreateSession value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update Session set Id_user=@Id_user, Date_session=@Date_session, Duration_session=@Duration_session where Id_session='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Id_user", value.Id_user);
            cmd.Parameters.AddWithValue("@Date_session", value.Date_session);
            cmd.Parameters.AddWithValue("@Duration_session", value.Duration_session);
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



        // DELETE: api/Session/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from Session where Id_session='" + id + "'", cmd);
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
