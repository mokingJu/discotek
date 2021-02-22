using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Session
    {
       public int Id_session { get; set; }
       public int Id_user { get; set; }
       public Nullable<System.DateTime> Date_session { get; set; }
       public Nullable<System.TimeSpan> Duration_session { get; set; }
    }

    public class CreateSession : Session { }

    public class ReadSession : Session
    {
       public ReadSession(DataRow row)
       {
            Id_session = (int)row["Id_session"];
            Id_user = (int)row["Id_user"];
            Date_session = Convert.ToDateTime(row["Date_session"]);
            Duration_session = TimeSpan.Parse(row["Duration_session"].ToString());
        }
    }

}