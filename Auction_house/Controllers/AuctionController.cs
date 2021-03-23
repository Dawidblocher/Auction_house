using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Auction_house.Data;
using Auction_house.Entity;
using Auction_house.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Auction_house.Controllers
{
    
    public class AuctionController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ApplicationDbContext _dbContext;

        private IWebHostEnvironment _hostingEnvironment;
        public AuctionController​(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _hostingEnvironment = environment;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auction = _dbContext.Auctions
                .Where(x => x.Id == id)
                .First();

            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        [HttpPost]
        public bool Index(int id, double price) {
            var result = false;
            

            var auction = _dbContext.Auctions
                .Where(x => x.Id == id)
                .First();

            if (auction == null)
            {
                return result;
            }
            else
            {
                if (price <= auction.Price) {
                    return result;
                }
                else
                {
                    var userId = _userManager.GetUserId(User);
                    auction.Price = price;
                    auction.Auctioner = User.Identity.Name;
                    _dbContext.SaveChanges();
                    result = true;
                }
                
            }


            return result;
        }


        [HttpGet]
        public IActionResult AddAuction()
        {          
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuction(AuctionModel auction) 
        {
            var file = HttpContext.Request.Form.Files[0];
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath, "img/auctionThumbs");

                    string filePath = Path.Combine(uploads, file.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }




            var viewEntity = new AuctionEntity
            {
                Name = auction.Name,
                Description = auction.Description,
                StartPrice = auction.StartPrice,
                Price = auction.StartPrice,
                Category = auction.Category,
                Auctioner = null,
                EndDate = auction.EndDate,
                fileName = file.FileName
            };



            var viewModel = new AuctionAddedViewModel
            {
                Name = auction.Name,
                Description = auction.Description,
                StartPrice = auction.StartPrice,
                Category = auction.Category,
                fileName = file.FileName
            };

          ;

            _dbContext.Auctions.Add(viewEntity);
            _dbContext.SaveChanges();

            return View("AuctionAdded", viewModel);
        }

       


    }
}
