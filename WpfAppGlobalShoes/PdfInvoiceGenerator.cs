using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;
using System.Windows;
using WpfAppGlobalShoes.Models;

public static class PdfInvoiceGenerator
{

public static void GeneratePdfInvoice(Sale sale, Client client)
{
    try
    {
        // Path to save the PDF file to the user's desktop
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName = $"Invoice_{sale.SaleID}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
        string filePath = Path.Combine(desktopPath, fileName);

        // Initialize PDF document
        using (Document document = new Document(PageSize.A4, 50, 50, 25, 25))
        {
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // Add Business Name and Logo (optional)
            var logoPath = "C:/Users/21650/Desktop/GSLogo.png"; // Optional: add a logo
            if (File.Exists(logoPath))
            {
                Image logo = Image.GetInstance(logoPath);
                logo.ScaleAbsolute(120, 60);
                logo.Alignment = Element.ALIGN_LEFT;
                document.Add(logo);
            }

            

            // Invoice title
            var invoiceTitle = new Paragraph($"Invoice {sale.SaleID}", FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK));
            invoiceTitle.Alignment = Element.ALIGN_RIGHT;
            document.Add(invoiceTitle);

            // Add Issue Date (only)
            var issueDate = new Paragraph($"Issue date: {DateTime.Now:dd/MM/yyyy}", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            issueDate.Alignment = Element.ALIGN_RIGHT;
            document.Add(issueDate);

            // Add a separator line
            document.Add(new Chunk(new LineSeparator(1, 100, BaseColor.BLACK, Element.ALIGN_CENTER, -2)));

            // "Bill To" section with client details
            var billTo = new Paragraph("BILL TO", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK));
            billTo.SpacingBefore = 10;
            document.Add(billTo);

            var clientDetails = new Paragraph($"{client.FirstName} {client.LastName}\n{client.CompanyName}\n{client.AddressLine}\n{client.City}, {client.State}\n{client.Country}",
                FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            document.Add(clientDetails);

            // Add space before the table
            document.Add(new Paragraph(" "));

            // Add a table for invoice details
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            float[] columnWidths = { 40, 20, 20, 20 };
            table.SetWidths(columnWidths);

            // Table headers
            PdfPCell cell = new PdfPCell(new Phrase("Description", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.WHITE)));
            cell.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Quantity", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.WHITE)));
            cell.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Unit Price", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.WHITE)));
            cell.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.WHITE)));
            cell.BackgroundColor = BaseColor.DARK_GRAY;
            table.AddCell(cell);

            // Sale details row
            table.AddCell(sale.Product.ProductName); // Assuming you have the Product details in sale
            table.AddCell(sale.QuantitySold.ToString());
            table.AddCell(sale.UnitPrice.ToString()+"DT");
            table.AddCell(sale.TotalPrice.ToString()+"DT");

            // Add the table to the document
            document.Add(table);

            // Total price
            var totalPrice = new Paragraph("Total: "+sale.TotalPrice.ToString() + " DT", FontFactory.GetFont("Arial", 14, Font.BOLD, BaseColor.BLACK));
            totalPrice.Alignment = Element.ALIGN_RIGHT;
            totalPrice.SpacingBefore = 10;
            document.Add(totalPrice);

            // Optional: Signature area
            var signatureLabel = new Paragraph("Issued by, signature:", FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK));
            signatureLabel.SpacingBefore = 40;
            document.Add(signatureLabel);

            // Close the document
            document.Close();
        }

        // Notify user of success
        MessageBox.Show($"Invoice1 saved to desktop: {filePath}");
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while generating the invoice: {ex.Message}");
    }
}
        
}
