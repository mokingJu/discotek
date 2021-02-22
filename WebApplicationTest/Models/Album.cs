using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Album
    {
        public string Id_album { get; set; }
        public string Id_artist { get; set; }
        public int Id_genre { get; set; }
        public string Name_album { get; set; }
        public Nullable<System.DateTime> DateRelease { get; set; }
        public Nullable<System.TimeSpan> Duration_album { get; set; }
        public byte[] Cover_album { get; set; }
    }

    public class CreateAlbum : Album{}

    public class ReadAlbum : Album
    {
        public ReadAlbum(DataRow row)
        {
            Id_album = row["Id_album"].ToString();
            Id_artist = row["Id_artist"].ToString();
            //Id_genre = Convert.ToInt32(row["Id_genre"]);
            Id_genre = (int)row["Id_genre"];
            Name_album = row["Name_album"].ToString();
            DateRelease = Convert.ToDateTime(row["DateRelease"]); 
            Duration_album = TimeSpan.Parse(row["Duration_album"].ToString());
            Cover_album = (byte[])row["Cover_album"];
        }
    }
}