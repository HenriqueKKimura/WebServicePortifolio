using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Http;
using WebServicePratic.Models;

namespace WebServicePratic.Controllers
{
    public class ClientesAPIController : ApiController
    {
        public Clientes GetClientPerPage(int itemsPorPagina, int pagina, string ca)
        {
            bool Verificacao = Autenticacao.AutenticacaoService(ca);
            var clientes = new Clientes();

            if (Verificacao)
            {
                string conString = ConfigurationManager.ConnectionStrings["getConnection"].ConnectionString;
                MySqlConnection connection = new MySqlConnection(conString);

                MySqlCommand cmd = new MySqlCommand("select cod,nom,end from clientes order by cod limit @itemsPorPagina OFFSET @pagina", connection);
                cmd.Parameters.AddWithValue("@itemsPorPagina", itemsPorPagina);
                cmd.Parameters.AddWithValue("@pagina", pagina * itemsPorPagina);

                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = reader["cod"].ToString(),
                        Nome = reader["nom"].ToString(),
                        Endereco = reader["end"].ToString()
                    };
                    clientes.cli.Add(cliente);
                }
                connection.Close();
                return clientes;
            }
            else
            {
                return clientes;
            }
        }
    }
}
