using System;
using System.Collections.Generic;

namespace Item_Marketplace;

public partial class Auction
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public DateTime CreatedDt { get; set; }

    public DateTime FinishedDt { get; set; }

    public decimal Price { get; set; }

    public string? Seller { get; set; }

    public string? Buyer { get; set; }

    public virtual Item Item { get; set; } = null!;
}
