using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace LendingToolMVC.Controllers
{
    public class BaseApiController : ApiController
    {
        protected static IMongoClient Client;
        protected static IMongoDatabase Database;

        protected void IntitalizeDatabase()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("lendingDatabase");
        }

        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var serializer = new JavaScriptSerializer();
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(serializer.Serialize(obj), encoding: Encoding.UTF8, mediaType: "/json");
            return response;
        }

    }
}