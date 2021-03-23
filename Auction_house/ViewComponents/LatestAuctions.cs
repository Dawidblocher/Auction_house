using Microsoft.AspNetCore.Mvc;
using Auction_house.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction_house.ViewComponents
{
    public class LatestAuctions : ViewComponent
    {
        public readonly ApplicationDbContext _dbContext;

        public LatestAuctions(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IViewComponentResult Invoke()
        {
            var latestItems = _dbContext.Auctions.OrderByDescending(x => x.Id).ToList();
            
            return View("Index", latestItems);
        }
    }
}
