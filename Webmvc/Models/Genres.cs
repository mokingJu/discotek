using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationTest.Models;

namespace Webmvc.Models
{
    public class Genres
    {
        public int selectedid { get; set; }
        TopicManager tm = new TopicManager();
        //ok
        public List<Genre> GetGenresFromAPI()
        {
            string id = string.Empty;
            List<Genre> liste = new List<Genre>();
            var resultlist = new List<Genre>();
            try
            {
                liste = tm.GetTopicById(resultlist, "http://localhost:57073/api/Genre", id);
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Genre> GetGenresByIdFromAPI(int id)
        {
            List<Genre> liste = new List<Genre>();
            var resultlist = new List<Genre>();
            try
            {
                liste = tm.GetTopicByIdInt(resultlist, "http://localhost:57073/api/Genre/", id);
                return liste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}