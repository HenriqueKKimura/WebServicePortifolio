using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebServicePratic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Adicionado para remover o formato XML e assim ficar só como JSON
            var removeXML = GlobalConfiguration.Configuration.Formatters;
            removeXML.Remove(removeXML.XmlFormatter);
        }
    }
}
