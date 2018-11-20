using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using LendingToolMVC.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace LendingToolMVC.Controllers
{
    public class UserApiController : BaseApiController
    {

        public HttpResponseMessage Get()
        {
            this.IntitalizeDatabase();
            var collection = Database.GetCollection<BsonDocument>("users");
            var test = collection.Find(a => true).ToList();
            var returnList = new List<User>();
            if (test.Count != 0)
            {
                returnList = test.Select(kpi => BsonSerializer.Deserialize<User>(kpi)).ToList();
            }
            return this.ToJson(returnList);
        }
    }
}