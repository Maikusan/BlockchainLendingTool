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
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace LendingToolMVC.Controllers
{
    public class UsersController : BaseApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            this.IntitalizeDatabase();
            var collection = Database.GetCollection<BsonDocument>("users");
            var test = collection.Find(a => true).ToList();
            if (test.Count != 0)
            {
                return test.Select(kpi => BsonSerializer.Deserialize<User>(kpi));
            }
            return null;
        }

        public User GetUser(int id)
        {
            this.IntitalizeDatabase();
            var collection = Database.GetCollection<User>("users");
            var query = Query.EQ("_id", id);
            var oid = new ObjectId();
            var entity = collection.Find(a => a.Id == oid).FirstOrDefault();
            return entity;
        }
    }
}