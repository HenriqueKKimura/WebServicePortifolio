using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicePratic.Models
{
    public class Autenticacao
    {


        public static bool AutenticacaoService(string ca)
        {
            string token = "95102RLPS=Q@)!lfwv.za";
            if (ca == token)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}