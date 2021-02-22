using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplicationTest.Models;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class GenresController : Controller
    {
        TopicManager tm = new TopicManager();
        Genres g = new Genres();

        // GET: Genres
        public ActionResult LstMenu()
        {
            var genres = g.GetGenresFromAPI();
            return PartialView(genres);
        }

        [HttpPost]
        public ActionResult LstMenu(FormCollection form, int id_genre)
        {
            id_genre = Convert.ToInt32(form["id_genre"]);
            g.selectedid = id_genre;
            return RedirectToAction("AbumsByGenre", "Albums", new { id = g.selectedid });
        }
    }
}