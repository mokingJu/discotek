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
    public class Content_sessionController : ApiController
    {
        Connexion conn = new Connexion();

        // GET: api/Content_session
        [HttpGet]
        public IEnumerable<Content_session> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Content_session", _dt);
            List<Content_session>content_sessions = new List<Content_session>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow Content_sessionRecord in _dt.Rows)
                {
                    content_sessions.Add(new ReadContent_session(Content_sessionRecord));
                }
            }
            return content_sessions;
        }
        
        // GET: api/Content_session/5
        [Route("api/Content_session/{id}")]
        [HttpGet]
        public IEnumerable<Content_session> Get(int id)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Content_session where Id_session='" + id + "'", _dt);
            List<Content_session> content_sessions = new List<Content_session>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow Content_sessionRecord in _dt.Rows)
                {
                    content_sessions.Add(new ReadContent_session(Content_sessionRecord));
                }
            }
            return content_sessions;
        }


        // POST: api/Content_session
        public string Post([FromBody]CreateContent_session value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into Content_session(Id_session, Id_album)values(@Id_session, @Id_album)", cmd);
            cmd.Parameters.AddWithValue("@Id_session", value.Id_session);
            cmd.Parameters.AddWithValue("@Id_album", value.Id_album);
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


        // PUT: api/Content_session/5
        public string Put(int id, [FromBody]CreateContent_session value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update Content_session set Id_session=@Id_session, Id_album=@Id_album where Id_session='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Id_session", value.Id_session);
            cmd.Parameters.AddWithValue("@Id_user", value.Id_album);
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

        // DELETE: api/Content_session/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from Content_session where Id_session='" + id + "'", cmd);
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
