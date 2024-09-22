using System;
using WpfAppGlobalShoes.Models;

public class Charge
{
    public int ChargeID { get; set; }

    public string ChargeType { get; set; }

    public decimal Amount { get; set; }

    public DateTime ChargeDate { get; set; }

    public string Description { get; set; }

    public string PaidStatus { get; set; }

    public DateTime? DueDate { get; set; }  // Nullable

    public DateTime? PaymentDate { get; set; }  // Nullable

    public int EmployeeID { get; set; }

    public Employee Employee { get; set; }
}
