using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Genre
    {
        public int Id_genre { get; set; }
        public string Name_genre { get; set; }
    }

    public class CreateGenre : Genre{}

    public class ReadGenre : Genre
    {
        public ReadGenre(DataRow row)
        {
            Id_genre = Convert.ToInt32(row["Id_genre"]);
            Name_genre = row["Name_genre"].ToString();
        }
    }
}