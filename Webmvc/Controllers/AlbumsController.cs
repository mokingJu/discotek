using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class AlbumsController : Controller
    {
        Albums al = new Albums();
        Artists ar = new Artists();

        // GET: Albums
        public ActionResult AllAlbums()
        {
            var albums = al.GetAlbumsFromAPI();

            var artists = ar.GetArtistsFromAPI();
            ViewBag.Dico = new Dictionary<string, string>();
            var query = from artist in artists
                        select new
                        {
                            artist.Id_artist,
                            artist.Name_artist
                        };
            foreach( var item in query)
            {
                ViewBag.Dico.Add( item.Id_artist, item.Name_artist);
            }

            return View(albums);
        }


        public ActionResult AbumsByArtist(string id_artist)
        {
            Artists ar = new Artists();
            var artists = ar.GetArtistsFromAPI();

            var artistList = from artist in artists
                             where artist.Id_artist == id_artist
                             select artist;
            foreach (var item in artistList)
                ViewBag.Title = item.Name_artist;

            var albums = al.GetAlbumsbyIdFromAPI(id_artist);
            return View(albums);
        }

        public ActionResult AbumsByGenre(int id_genre)
        {
            Genres styles = new Genres();
            var genres = styles.GetGenresByIdFromAPI(id_genre);
            var genreList = from genre in genres
                            where genre.Id_genre == id_genre
                            select genre;
            foreach (var item in genreList)
                ViewBag.Title = item.Name_genre;

            var artists = ar.GetArtistsFromAPI();
            ViewBag.Dico = new Dictionary<string, string>();
            var query = from artist in artists
                        select new
                        {
                            artist.Id_artist,
                            artist.Name_artist
                        };
            foreach (var item in query)
            {
                ViewBag.Dico.Add(item.Id_artist, item.Name_artist);
            }

            List < Album > liste = new List<Album>();
            liste = al.GetAlbumsbyGenreFromAPI(id_genre);
            return View(liste);
        }

        public ActionResult SearchEngine()
        {
            var artists = ar.GetArtistsFromAPI();
            ViewBag.result = artists;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Search()
        {
            string testvar = Request["testvar"];
            return RedirectToAction("AbumsByArtist", "Albums", new { @id_artist = testvar });
        }
    }
}