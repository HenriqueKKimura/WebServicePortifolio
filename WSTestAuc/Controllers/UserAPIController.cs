using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebServicePratic.Models;

namespace WebServicePratic.Controllers
{
    public class UserAPIController : ApiController
    {
        public UsersDetail GetUsuarioDetail(string user, string pass)
        {
            if (user.Length > 14 || pass.Length > 100)
            {
                throw new HttpException(400, "Bad Request");
            }
            else
            {
            var usuarios = new UsersDetail();

            string conString = ConfigurationManager.ConnectionStrings["getConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(conString);

            MySqlCommand cmd = new MySqlCommand($"SELECT cpf, passwordapp FROM vendedor WHERE cpf = @Usuario AND passwordapp = @Pass", connection);
            cmd.Parameters.AddWithValue("@Usuario", user);
            cmd.Parameters.AddWithValue("@Pass", pass);

                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User users = new User
                    {
                        CPF = reader["cpf"].ToString(),
                        Password = reader["passwordapp"].ToString()
                    };
                    usuarios.Usuarios.Add(users);
                }
                connection.Close();
                return usuarios;

            }



        }
    }
}
