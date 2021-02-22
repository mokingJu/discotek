using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebApplicationTest.Models;

namespace Webmvc.Models
{
    public class Soundtracks
    {
        TopicManager tm = new TopicManager();

        public List<Soundtrack> GetSoundtracksFromAPI()
        {
            string id = string.Empty;
            List<Soundtrack> liste = new List<Soundtrack>();
            var resultlist = new List<Soundtrack>();
            try
            {
                liste = tm.GetTopicById(resultlist, "http://localhost:57073/api/Soundtrack/", id);
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Soundtrack> GetSoundtracksByAlbumFromAPI(string id_album)
        {
            try
            {
                List<Soundtrack> liste = new List<Soundtrack>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("http://localhost:57073/api/Soundtrack/SonudtracksByAlbumId/" + id_album )
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<Soundtrack>>();
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