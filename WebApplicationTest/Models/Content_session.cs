using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Content_session
    {
        public int Id_session { get; set; }
        public string Id_album { get; set; }
    }

    public class CreateContent_session : Content_session { }

    public class ReadContent_session : Content_session
    {
        public ReadContent_session(DataRow row)
        {
            Id_session = (int)row["Id_session"];
            Id_album = row["Id_album"].ToString();
        }
    }

}