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
    public class ArtistController : ApiController
    {
        Connexion conn = new Connexion();

        // GET: api/Artist
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Artist", _dt);
            List<Artist> artists = new List<Artist>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow artistRecord in _dt.Rows)
                {
                    artists.Add(new ReadArtist(artistRecord));
                }
            }
            return artists;
        }

        // POST: api/Artist
        public string Post([FromBody]CreateArtist value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into Artist(Id_artist, Name_artist, Nationality) values(@Id_artist, @Name_artist, @Nationality)", cmd);
            cmd.Parameters.AddWithValue("@Id_artist", value.Id_artist);
            cmd.Parameters.AddWithValue("@Name_artist", value.Name_artist);
            cmd.Parameters.AddWithValue("@Nationality", value.Nationality);
            int result=cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return "insertion réussie";
            }
            else
            {
                return "echec insertion";
            }
        }

        // PUT: api/Artist/5
        public string Put(string id, [FromBody]CreateArtist value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update Artist set Name_artist=@Name_artist, Nationality=@Nationality where Id_artist='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Name_artist", value.Name_artist);
            cmd.Parameters.AddWithValue("@Nationality", value.Nationality);
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

        // DELETE: api/Artist/5
        public string Delete(string id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from Artist where Id_artist='" + id + "'", cmd);
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
