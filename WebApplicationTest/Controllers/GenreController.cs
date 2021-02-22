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
    public class GenreController : ApiController
    {
        Connexion conn = new Connexion();

        // GET: api/Genre
        [HttpGet]
        public IEnumerable<Genre> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Genre", _dt);

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-L2O4DMO\\SQLEXPRESS;Initial Catalog=BDmusicOnLine;Integrated Security=True");
            List<Genre> genres = new List<Genre>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow GenreRecord in _dt.Rows)
                {
                    genres.Add(new ReadGenre(GenreRecord));
                }
            }
            return genres;
        }

        // GET: api/Genre/5
        [Route("api/Genre/{id}")]
        [HttpGet]
        public IEnumerable<Genre> Get(int id)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Genre where Id_genre='" + id + "'", _dt);
            List<Genre> genres = new List<Genre>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow GenreRecord in _dt.Rows)
                {
                    genres.Add(new ReadGenre(GenreRecord));
                }
            }
            return genres;
        }

        // POST: api/Genre
        public string Post([FromBody]CreateGenre value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into Genre(Name_genre) values( @Name_genre)", cmd);
            //Id_genre auto incrémenté par sql server(gestion de l'Id par sql server)
            cmd.Parameters.AddWithValue("@Name_genre", value.Name_genre);
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

        // PUT: api/Genre/5
        public string Put(int id, [FromBody]CreateGenre value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update Genre set Name_genre=@Name_genre where Id_genre='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Name_genre", value.Name_genre);
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


        // DELETE: api/Genre/5
        public string Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from Genre where Id_genre='" + id + "'", cmd);
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
