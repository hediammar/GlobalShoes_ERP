using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class AddSaleWindow : Window
    {
        public AddSaleWindow()
        {
            InitializeComponent();
            LoadProducts();
            LoadClients();
        }

        private void LoadClients()
        {
            using (var context = new GSDBContext())
            {
                var clients = context.Clients
                    .Select(c => new { c.ClientID, FullName = c.FirstName + " " + c.LastName })
                    .ToList();
                ClientComboBox.ItemsSource = clients;
                ClientComboBox.SelectedValuePath = "ClientID";  // Set selected value path here
            }
        }

        private void LoadProducts()
        {
            using (var context = new GSDBContext())
            {
                var products = context.Products
                    .Select(p => new { p.ProductID, p.ProductName })
                    .ToList();
                ProductComboBox.ItemsSource = products;
                ProductComboBox.SelectedValuePath = "ProductID";
            }

            ProductComboBox.SelectionChanged += ProductComboBox_SelectionChanged;
        }

        private void ProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductComboBox.SelectedValue != null)
            {
                int selectedProductId = (int)ProductComboBox.SelectedValue;

                using (var context = new GSDBContext())
                {
                    var product = context.Products
                        .Where(p => p.ProductID == selectedProductId)
                        .Select(p => new { p.ProductName, Inventory = p.Inventory.QuantityInStock })
                        .FirstOrDefault();

                    if (product != null)
                    {
                        StockQuantityTextBlock.Text = $"Stock Quantity: {product.Inventory}";
                    }
                }
            }
        }



        private void AddSaleButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GSDBContext())
            {
                int productId = (int)ProductComboBox.SelectedValue;
                var product1 = context.Products.FirstOrDefault(p => p.ProductID == productId);
                var selectedProductId = (int)ProductComboBox.SelectedValue;
                var enteredQuantity = int.Parse(QuantitySoldTextBox.Text);

                var product = context.Inventory
                    .Where(i => i.ProductID == selectedProductId)
                    .FirstOrDefault();

                if (product != null)
                {
                    // Check if entered quantity is greater than available stock
                    if (enteredQuantity > product.QuantityInStock)
                    {
                        MessageBox.Show("The quantity entered exceeds the available stock. Please enter a valid quantity.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return; // Exit the method to prevent further execution
                    }

                    // Retrieve client information
                    int clientId = (int)ClientComboBox.SelectedValue;
                    var client = context.Clients.FirstOrDefault(c => c.ClientID == clientId);

                    var sale = new Sale
                    {
                        ProductID = selectedProductId,
                        QuantitySold = enteredQuantity,
                        UnitPrice = product1.Price,
                        ClientID = clientId,
                        SaleDate = DateTime.Now,
                        EmployeeID = Session.CurrentUserId
                    };

                    // Update inventory
                    product.QuantityInStock -= enteredQuantity;
                    context.Sales.Add(sale);
                    context.SaveChanges();

                    // Generate invoice as PDF with client details
                    PdfInvoiceGenerator.GeneratePdfInvoice(sale, client);
                   
                    MessageBox.Show("Sale added successfully!");
                }
            }
        }



    }
}
