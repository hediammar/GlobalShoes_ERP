using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfAppGlobalShoes.Models
{
    public class Inventory
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public int QuantityInStock { get; set; }
        public DateTime LastRestockDate { get; set; }
        public int MinimumStockLevel { get; set; }

        public Product Product { get; set; }  // Navigation property
    }
}
