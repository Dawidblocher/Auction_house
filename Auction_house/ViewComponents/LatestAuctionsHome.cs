using Microsoft.AspNetCore.Mvc;
using Auction_house.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_house.ViewComponents
{
    public class LatestAuctionsHome : ViewComponent
    {
        public readonly ApplicationDbContext _dbContext;

        public LatestAuctionsHome(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var latestItemsHome = _dbContext.Auctions.OrderByDescending(x => x.Id).Take(4).ToList();
            
            return View("Index", latestItemsHome);
        }
    }
}
