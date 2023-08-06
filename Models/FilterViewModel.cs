using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Item_Marketplace.Models
{
    public class FilterViewModel
    {
        public SelectList Auctions { get; private set; }  // вибраний аукціон
        public string SelectedStatus { get; private set; }   // вибраний статус
        public string SelectedSeller { get; private set; }    // вибраний продавець

        public FilterViewModel (List<Auction> auctions, string status, string seller)
        {
            // встановлюємо початковий елемент який дозволить обрати всі
            auctions.Insert(0, new Auction { Seller = "all", Id = 0 });
            var Auctions = new SelectList(auctions, "status", "seller" );
            SelectedStatus = status;
            SelectedSeller = seller;

        }
        
    }
}
