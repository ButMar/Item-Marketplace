using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace Item_Marketplace.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime FinishedDt { get; set; }
        public decimal Price { get; set; }
        public enum Status
        {
            None,
            Canceled,
            Finished,
            Active
        }
        public string? Seller { get; set; }
        public string? Buyer { get; set; }

       // [NotMapped]
        public virtual Item? Item { get; set; }

        public List<Item> Items { get; set; }

        public Auction()
        {
            Items = new List<Item>();
        }

    }
}
