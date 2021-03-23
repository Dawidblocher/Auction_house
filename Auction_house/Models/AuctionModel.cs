
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
namespace Auction_house.Models
{
    public class AuctionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public string Category { get; set; }
    
        public int AuctionerId { get; set; }

        public DateTime EndDate { get; set; }

        public IFormFile file { get; set; }
}
} 
