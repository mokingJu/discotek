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
    public class SoundtrackController : ApiController
    {

        Connexion conn = new Connexion();

        // GET: api/Soundtrack
        [HttpGet]
        public IEnumerable<Soundtrack> Get()
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Soundtrack", _dt);
            List<Soundtrack> soundtracks = new List<Soundtrack>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow SoundtrackRecord in _dt.Rows)
                {
                    soundtracks.Add(new ReadSoundtrack(SoundtrackRecord));
                }
            }
            return soundtracks;
        }

        //GET: api/Soundtrack/"..."
        [Route("api/Soundtrack/SonudtracksByAlbumId/{id_album}")]
        [HttpGet]
        public IEnumerable<Soundtrack> GetSonudtracksByAlbumId(string id_album)
        {
            DataTable _dt = new DataTable();
            conn.Connectdb_Get("select * from Soundtrack where Id_album='" + id_album + "'", _dt);
            List<Soundtrack> soundtracks = new List<Soundtrack>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow SoundtrackRecord in _dt.Rows)
                {
                    soundtracks.Add(new ReadSoundtrack(SoundtrackRecord));
                }
            }
            return soundtracks;
        }


        // POST: api/Soundtrack
        public string Post([FromBody]CreateSoundtrack value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("insert into Soundtrack(Numero_track, Id_album, Name_track, Duration_track, Path_track)values(@Numero_track, @Id_album, @Name_track, @Duration_track, @Path_track)", cmd);
            cmd.Parameters.AddWithValue("@Numero_track", value.Numero_track);
            cmd.Parameters.AddWithValue("@Id_album", value.Id_album);
            cmd.Parameters.AddWithValue("@Name_track", value.Name_track);
            cmd.Parameters.AddWithValue("@Duration_track", value.Duration_track);
            cmd.Parameters.AddWithValue("@Path_track", value.Path_track);
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

        // PUT: api/Soundtrack/5
        //Insertion Cover album via interface
        public string Put(string id, [FromBody]CreateSoundtrack value)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("update Soundtrack set Numero_track=@Numero_track, Id_album=@Id_album, Name_track=@Name_track, Duration_track=@Duration_track, Path_track=@Path_track where Numero_track='" + id + "'", cmd);
            cmd.Parameters.AddWithValue("@Numero_track", value.Numero_track);
            cmd.Parameters.AddWithValue("@Id_album", value.Id_album);
            cmd.Parameters.AddWithValue("@Name_track", value.Name_track);
            cmd.Parameters.AddWithValue("@Duration_track", value.Duration_track);
            cmd.Parameters.AddWithValue("@Path_track", value.Path_track);
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

        // DELETE: api/Soundtrack/5
        public string Delete(string id)
        {
            SqlCommand cmd = new SqlCommand();
            conn.Connectdb("delete from Soundtrack where Numero_track='" + id + "'", cmd);
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
