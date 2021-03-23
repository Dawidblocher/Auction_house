using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_house.Entity
{
    public class AuctionEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public double Price { get; set; }
         
        public string Category { get; set; }

        public string Auctioner { get; set; }
        
        public DateTime EndDate { get; set; }

        public string fileName { get; set; }
    }
}
