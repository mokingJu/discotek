using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webmvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "AbumsByGenre",
                url: "{controller}/{action}/{id_genre}",
                new { controller = "Albums", action = "AbumsByGenre", id = "id_genre" }
            );


            routes.MapRoute(
                name: "GetArtistByFirstCaracter",
                url: "{controller}/{action}/{id_letter}",
                new { controller = "Artists", action = "GetArtistByFirstCaracter" },
                constraints: new { id_letter = @"^[0-9]+$" }
            );

            routes.MapRoute(
                name: "GetSoundtracksAlbumFromAPI",
                url: "{controller}/{action}/{id_album}",
                new { controller = "Soundtracks", action = "GetSoundtracksAlbumFromAPI" }, 
                constraints:new { id_album = @"^[0-9]+$" } 
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Albums", action = "AllAlbums", id = UrlParameter.Optional }
            );



        }
    }
}
