using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class User
    {
        public int Id_user { get; set; }
        public string Name_user { get; set; }
        public string Email_user { get; set; }
        public string Password_user { get; set; }     
    }

    public class CreateUser : User {}

    public class ReadUser : User
    {
        public ReadUser(DataRow row)
        {
            Id_user =(int) row["Id_user"];
            Name_user = row["Name_user"].ToString();
            Email_user = row["Email_user"].ToString();
            Password_user = row["Password_user"].ToString();
        }
    }
}