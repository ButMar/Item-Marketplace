using System;
using System.Collections.Generic;

namespace Item_Marketplace;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Metadata { get; set; }

    public virtual ICollection<Auction> Auctions { get; set; } = new List<Auction>();
}
