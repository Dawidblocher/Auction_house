using Auction_house.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_house.Areas.Identity.Data
{
    public class AuctionUser : IdentityUser
    {
        [PersonalData]
        public AuctionEntity Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
