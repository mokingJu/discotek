using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Artist
    {
        public string Id_artist { get; set; }
        public string Name_artist { get; set; }
        public string Nationality { get; set; }
    }

    public class CreateArtist : Artist{}

    public class ReadArtist : Artist
    {
        public ReadArtist(DataRow row)
        {
            Id_artist = row["Id_artist"].ToString();
            Name_artist = row["Name_artist"].ToString();
            Nationality = row["Nationality"].ToString();
        }
        
    }
}