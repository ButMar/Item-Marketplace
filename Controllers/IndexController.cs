using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Item_Marketplace.DataAccess;
using Microsoft.EntityFrameworkCore;
using static Item_Marketplace.Models.SortViewModel;
using Item_Marketplace.Models;


namespace Item_Marketplace.Controllers
{
    public class IndexController : Controller
    {

        ItemDbContext db;
        public IndexController (ItemDbContext context)
        {
            this.db = context;

            // додаєм початкові дані
            if (db.Auction.Count() == 0)
            {
                Auction simpl = new Auction { Seller = "simpl" };
                Auction viyar = new Auction { Seller = "simpl" };
                Auction grade = new Auction { Seller = "grade" };

                Item nomber1 = new Item { Name = "table", Auction = simpl, Description = "wood" };
                Item nomber2 = new Item { Name = "table", Auction = simpl, Description = "plastic" };
                Item nomber3 = new Item { Name = "chair", Auction = viyar, Description = "wood" };
                Item nomber4 = new Item { Name = "chair", Auction = viyar, Description = "plastic" };
                Item nomber5 = new Item { Name = "sofa", Auction = grade, Description = "textile" };
                Item nomber6 = new Item { Name = "sofa", Auction = grade, Description = "skin" };
                

                db.Auction.AddRange(simpl, viyar, grade);
                db.Item.AddRange(nomber1, nomber2, nomber3, nomber4, nomber5, nomber6);
                db.SaveChanges();
            }
        }
        public async Task<IActionResult> Index (int? auction, string name, int page = 1,
            SortState sortOrder = SortState.CreatedDtDesc)
        {
            int pageSize = 3;

            // фільтрація
            IQueryable<Item> item = db.Item.Include(x => x.Auction);

            if (auction != null && auction != 0)
            {
                item = item.Where(p => p.Id == auction);
            }
            if (!String.IsNullOrEmpty(name))
            {
                item = item.Where(p => p.Name.Contains(name));
            }

            // сортування
            IQueryable<Auction> auctioner = db.Auction.Include(x => x.Item);
            switch (sortOrder)
            {
                case SortState.CreatedDtDesc:
                    auctioner = auctioner.OrderByDescending(s => s.CreatedDt);
                    break;
                case SortState.CreatedDtAsc:
                    auctioner = auctioner.OrderBy(s => s.CreatedDt);
                    break;
                case SortState.PriceDesc:
                    auctioner = auctioner.OrderByDescending(s => s.Price);
                    break;
                case SortState.PriceAsc:
                    auctioner = auctioner.OrderBy(s => s.Price);
                    break;
                default:
                    item = item.OrderBy(s => s.Name);
                    break;
            }

            // пагінация
            var count = await item.CountAsync();
            var items = await item.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формуємо модель представлення
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Auction.ToList(), "auction", name)
            };
            return View(viewModel);
        }

        //[HttpGet(Name = "GETInformation")]
        //public object GETInformation()
        //{

        //}

    }
}
