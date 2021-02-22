using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class ArtistsController : Controller
    {
        TopicManager tm = new TopicManager();
        Artists ar = new Artists();

        // GET: Artists
        public ActionResult Index()
        {
            var artists = ar.GetArtistsFromAPI();
            return View(artists);
        }

        //[HttpPost]
        public ActionResult GetArtistByFirstCaracter(FormCollection form, string id_letter)
        {
            var artists = ar.GetArtistsFromAPI();

            ViewBag.items = new Dictionary<string, string>();
            var d_List = from artist in artists
                         where artist.Name_artist.Contains(id_letter)
                         select new{ artist.Name_artist, artist.Id_artist};                             
            foreach(var item in d_List)
            {
                ViewBag.items.Add(item.Name_artist, item.Id_artist);
            }
            return View();
        }

        ////[HttpGet]
        //public ActionResult SearchEngine()
        //{
        //    var artists = ar.GetArtistsFromAPI();
        //    ViewBag.result = artists;
        //    return PartialView (ViewBag.result);
        //}

        //public ActionResult SearchEngine()
        //{
        //    var artists = ar.GetArtistsFromAPI();            
        //    ViewBag.result = artists;
        //    return PartialView();
        //}
    }
}