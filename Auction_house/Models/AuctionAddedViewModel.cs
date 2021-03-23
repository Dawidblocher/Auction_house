using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_house.Models
{
    public class AuctionAddedViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public string Category { get; set; }
        public string fileName { get; set; }
    }
}
