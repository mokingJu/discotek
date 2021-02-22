using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Models;
using Webmvc.Models;

namespace Webmvc.Controllers
{
    public class SoundtracksController : Controller
    {
        TopicManager tm = new TopicManager();
        Soundtracks s = new Soundtracks();

        // GET: Soundtracks
        public ActionResult Index()
        {
            var soundtracks = s.GetSoundtracksFromAPI();
            return View();
        }

        //ici çqa coince ne recupere pas l'id   !!!
        [Route("Sondtracks/GetSoundtracksAlbumFromAPI/id_album")]
        [HttpGet]
        public ActionResult GetSoundtracksAlbumFromAPI(string id_album)
        {
            var soundtracks = s.GetSoundtracksByAlbumFromAPI(id_album);
            List<string> lstName = new List<string>();

            foreach(var soundtrack in soundtracks )
            {
                lstName.Add(soundtrack.Name_track);

                //creer un fichier audio dans webmvc puis contenu sera généré dans fichier audio dans webmvc 'package appli'
                var data= Server.MapPath("~/audio/'" + soundtrack.Name_track + "'.mp3");
                FileStream file = new FileStream(@data, FileMode.Create, FileAccess.Write);

                if (file.CanWrite)
                {
                    file.Write(soundtrack.Path_track, 0, soundtrack.Path_track.Length);
                }
                file.Flush();
                file.Close();
            }
            foreach( string elemt in lstName)
            {
                var data = Server.MapPath("~/audio/'" + elemt  + "'.mp3");
                FileStream file = new FileStream(@data, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[file.Length];
                int bytesread = file.Read(buffer, 0, buffer.Length); 
            }

            return View(soundtracks);
        }
    }
}