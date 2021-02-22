using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebApplicationTest.Models;

namespace Webmvc.Models
{
    public class Albums
    {
        TopicManager tm = new TopicManager();

        //ok 
        public List<Album> GetAlbumsFromAPI()
        {
            string id = string.Empty;
            try
            {
                List<Album> liste = new List<Album>();
                var resultlist = new List<Album>();
                liste = tm.GetTopicById(resultlist, "http://localhost:57073/api/Album/", id);
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ok
        public List<Album> GetAlbumsbyIdFromAPI(string id_artist)
        {
            List<Album> liste = new List<Album>();
            var resultlistbyid = new List<Album>();
            try
            {
                liste = tm.GetTopicById(resultlistbyid, "http://localhost:57073/api/Album/AlbumsByArtist/", id_artist);
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //temporaire
        public List<Album> GetAlbumsbyGenreFromAPI(int id_genre)
        {
            try
            {
                List<Album> liste = new List<Album>();

                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:57073/api/Album/" + id_genre)
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Album>>();
                            readResult.Wait();

                            liste = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}