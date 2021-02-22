using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTest.Models;

namespace Webmvc.Models
{
    public class Artists
    {
        TopicManager tm = new TopicManager();

        public List<Artist> GetArtistsFromAPI()
        {
            string id = string.Empty;
            try
            {
                List<Artist> liste = new List<Artist>();
                var resultlist = new List<Artist>();
                liste = tm.GetTopicById(resultlist, "http://localhost:57073/api/Artist", id);
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}