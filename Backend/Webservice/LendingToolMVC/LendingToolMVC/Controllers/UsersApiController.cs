﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using LendingToolMVC.Helpers;
using LendingToolMVC.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace LendingToolMVC.Controllers
{
    [Route("api/[controller]")]
    /// <summary>
    /// User Controller
    /// </summary>
    public class UsersController : BaseApiController
    {

        [Route("users")]
        [HttpGet]
        /// <summary>
        /// Get All User from Database
        /// </summary>
        /// <returns>All User from Database</returns>
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

        [Route("user/{userId}")]
        [HttpGet]
        /// <summary>
        /// Get Users a specific User from d
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUser(int id)
        {
            this.IntitalizeDatabase();
            var collection = Database.GetCollection<User>("users");
            var query = Query.EQ("_id", id);
            var oid = "Jesus";
            var entity = collection.Find(a => a.Id == oid).FirstOrDefault();
            return entity;
        }

        [HttpPost]
        public HttpResponseMessage Add(User user)
        {

            this.IntitalizeDatabase();
            var collection = Database.GetCollection<BsonDocument>("users");
            var noError = "true";
            user.Id = Guid.NewGuid().ToString();
            try
            {
                collection.InsertOneAsync(user.ToBsonDocument());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                noError = e.Message;
            }

            return ToJson(noError);
        }

    }
}