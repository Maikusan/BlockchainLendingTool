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
    /// Rental Controller
    /// </summary>
    public class RentalsController : BaseApiController
    {
        [Route("rentals")]
        [HttpGet]
        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            EtheriumHelper eh = new EtheriumHelper();
            var yolo = new List<Rental>();
            await eh.ShouldBeAbleToEncodeDecodeComplexInputOutput();
            return yolo;
        }

    }
}