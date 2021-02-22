using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Soundtrack
    {
        public string Numero_track { get; set; }
        public string Id_album { get; set; }
        public string Name_track { get; set; }
        public Nullable<System.TimeSpan> Duration_track { get; set; }
        public byte[] Path_track { get; set; }
    }

    public class CreateSoundtrack : Soundtrack{}

    public class ReadSoundtrack : Soundtrack
    {
        public ReadSoundtrack(DataRow row)
        {

            Numero_track = row["Numero_track"].ToString();
            Id_album = row["Id_album"].ToString();
            Name_track = row["Name_track"].ToString();
            Duration_track = TimeSpan.Parse(row["Duration_track"].ToString());
            Path_track =(byte[])row["Path_track"];// pas d'encodage ascii

        }
    }
}