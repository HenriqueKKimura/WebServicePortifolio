using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicePratic.Models
{
    public class UsersDetail
    {
        public List<User> Usuarios { get; set; }


        public UsersDetail()
        {
            Usuarios = new List<User>();
        }
    }
}