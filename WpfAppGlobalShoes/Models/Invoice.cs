using System;

public class Invoice
{
    public int InvoiceID { get; set; }
    public int SaleID { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; }
    public string ClientName { get; set; }
}
