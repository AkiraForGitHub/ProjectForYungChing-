using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }
}
