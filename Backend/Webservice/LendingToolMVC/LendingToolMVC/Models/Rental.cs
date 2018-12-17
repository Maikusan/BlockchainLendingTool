using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LendingToolMVC.Helpers
{
    [FunctionOutput]
    public class Rental
    {
        [Parameter("address", "landlord", 1)]
        public string Landlord { get; set; }

        [Parameter("address", "tenant", 2)]
        public string Tenant{ get; set; }

        [Parameter("uint", "depositeAmount", 3)]
        public int DepositeAmount { get; set; }

        [Parameter("uint", "rentalPrice", 4)]
        public int RentalPrice { get; set; }

        [Parameter("uint", "endtime", 5)]
        public int Endtime { get; set; }

        [Parameter("uint", "itemId", 6)]
        public int ItemId { get; set; }


    }
}