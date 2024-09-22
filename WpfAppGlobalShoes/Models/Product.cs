using System;
using System.Collections.Generic;

namespace WpfAppGlobalShoes.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public int WarrantyPeriod { get; set; }

        public Inventory Inventory { get; set; }  // Navigation property

        public ICollection<Sale> Sales { get; set; } // Navigation property
    }
}
