
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
    public class AlbumController : ApiController
    {
        Connexion conn = new Connexion();

        // GET: api/Album
         [HttpGet]
        public IEnumerable<Album> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Album",_dt);
            List<Album> albums = new List<Album>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow albumRecord in _dt.Rows)
                {
                    albums.Add(new ReadAlbum(albumRecord));
                }
            }
            return albums;
        }

        // GET: api/Album/BEC-4
        [Route("api/Album/AlbumsByArtist/{id_artist}")]
        [HttpGet]
        public IEnumerable<Album> GetAlbumsByArtist(string id_artist)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Album where Id_artist='" + id_artist + "'", _dt);
            List<Album> albums = new List<Album>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow albumRecord in _dt.Rows)
                {
                    albums.Add(new ReadAlbum(albumRecord));
                }
            }
            return albums;
        }

        
        [Route("api/Album/{id_genre}")]
        [HttpGet]
        public IEnumerable<Album> GetByGenre(int id_genre)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Album where Id_genre='" + id_genre + "'", _dt);
            List<Album> albums = new List<Album>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow albumRecord in _dt.Rows)
                {
                    albums.Add(new ReadAlbum(albumRecord));
                }
            }
            return albums;
        }


        // POST: api/Album
        public string Post([FromBody]CreateAlbum value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into Album(Id_album, Id_artist, Id_genre, Name_album, DateRelease, Duration_album, Cover_album)values(@Id_album, @Id_artist, @Id_genre, @Name_album, @DateRelease, @Duration_album, @Cover_album)",cmd);
            cmd.Parameters.AddWithValue("@Id_album", value.Id_album);
            cmd.Parameters.AddWithValue("@Id_artist", value.Id_artist);
            cmd.Parameters.AddWithValue("@Id_genre", value.Id_genre);
            cmd.Parameters.AddWithValue("@Name_album", value.Name_album);
            cmd.Parameters.AddWithValue("@DateRelease", value.DateRelease);
            cmd.Parameters.AddWithValue("@Duration_album", value.Duration_album);
            cmd.Parameters.AddWithValue("@Cover_album", value.Cover_album);
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

        // PUT: api/Album/5
        public string Put(string id, [FromBody]CreateAlbum value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update Album set Id_album=@Id_album, Id_artist=@Id_artist, Id_genre=@Id_genre, Name_album=@Name_album, DateRelease=@DateRelease, Duration_album=@Duration_album, Cover_album=@Cover_album where Id_album='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Id_album", value.Id_album);
            cmd.Parameters.AddWithValue("@Id_artist", value.Id_artist);
            cmd.Parameters.AddWithValue("@Id_genre", value.Id_genre);
            cmd.Parameters.AddWithValue("@Name_album", value.Name_album);
            cmd.Parameters.AddWithValue("@DateRelease", value.DateRelease);
            cmd.Parameters.AddWithValue("@Duration_album", value.Duration_album);
            cmd.Parameters.AddWithValue("@Cover_album", value.Cover_album);
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

        // DELETE: api/Album/5
        public string Delete(string id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from Album where Id_album='" + id + "'", cmd);
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
