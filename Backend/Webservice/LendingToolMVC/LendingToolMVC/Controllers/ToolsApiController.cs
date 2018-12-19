using System;
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
    /// Tool Controller
    /// </summary>
    public class ToolsController : BaseApiController
    {

        [Route("tools")]
        [HttpGet]
        /// <summary>
        /// Get All Tool from Database
        /// </summary>
        /// <returns>All Tool from Database</returns>
        public IEnumerable<Tool> GetAllTools()
        {
            this.IntitalizeDatabase();
            var collection = Database.GetCollection<BsonDocument>("tools");
            var test = collection.Find(a => true).ToList();
            if (test.Count != 0)
            {
                return test.Select(kpi => BsonSerializer.Deserialize<Tool>(kpi));
            }
            return null;
        }



        [Route("tools/{toolId}")]
        [HttpGet]
        /// <summary>
        /// Get Tools a specific Tool from d
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tool GetTool(int id)
        {
            this.IntitalizeDatabase();
            var collection = Database.GetCollection<Tool>("tools");
            var query = Query.EQ("_id", id);
            var oid = "Jesus";
            var entity = collection.Find(a => a.Id == oid).FirstOrDefault();
            return entity;
        }

        [Route("tools")]
        [HttpPost]
        public HttpResponseMessage Add(Tool tool)
        {

            this.IntitalizeDatabase();
            var collection = Database.GetCollection<BsonDocument>("tools");
            var noError = "true";
            tool.Id = Guid.NewGuid().ToString();
            try
            {
                collection.InsertOneAsync(tool.ToBsonDocument());
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