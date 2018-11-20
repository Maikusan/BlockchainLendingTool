using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace LendingToolMVC.Controllers
{
    public class BaseApiController : ApiController
    {
        protected const string Tempfolder = @"C:\KPITool\temp\";
        protected const string Dynamicfolder = Tempfolder + @"latest\";
        protected const string Staticfolder = Tempfolder + @"static\";

        protected static IMongoClient Client;
        protected static IMongoDatabase Database;

        protected void IntitalizeDatabase()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("lendingDatabase");
        }

        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }

    }
}