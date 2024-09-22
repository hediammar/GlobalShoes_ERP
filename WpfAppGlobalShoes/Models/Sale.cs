using System;
using System.ComponentModel.DataAnnotations.Schema;
using WpfAppGlobalShoes.Models;

public class Sale
{
    public int SaleID { get; set; }
    public DateTime SaleDate { get; set; }
    public int ProductID { get; set; }
    public int QuantitySold { get; set; }
    public decimal UnitPrice { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal TotalPrice { get; set; } // Computed by SQL Server

    public int ClientID { get; set; }
    public int EmployeeID { get; set; }
    public string Status { get; set; } = "Pending";

    public virtual Product Product { get; set; }
    public virtual Client Client { get; set; }
    public virtual Employee Employee { get; set; }
    

}
