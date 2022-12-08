using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicePratic.Models
{
    public class Clientes
    {
      public  List<Cliente> cli { get; set; }

        public Clientes()
        {
            cli = new List<Cliente>();
        }
    }
}