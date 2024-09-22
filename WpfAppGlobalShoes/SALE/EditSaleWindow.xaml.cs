using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class EditSaleWindow : Window
    {
        private readonly int _saleId;

        public EditSaleWindow(int saleId)
        {
            InitializeComponent();
            _saleId = saleId;
            LoadSaleData();
            LoadProductData();
            LoadClientData();
        }

        private void LoadSaleData()
        {
            using (var context = new GSDBContext())
            {
                var sale = context.Sales
                    .Include(s => s.Product)
                    .Include(s => s.Client)
                    .FirstOrDefault(s => s.SaleID == _saleId);

                if (sale != null)
                {
                    ProductComboBox.SelectedValue = sale.Product.ProductID;
                    QuantitySoldTextBox.Text = sale.QuantitySold.ToString();
                    ClientComboBox.SelectedValue = sale.Client.ClientID;
                    StatusComboBox.SelectedItem = sale.Status;
                }
            }
        }

        private void LoadProductData()
        {
            using (var context = new GSDBContext())
            {
                var products = context.Products.ToList();
                ProductComboBox.ItemsSource = products;
            }
        }

        private void LoadClientData()
        {
            using (var context = new GSDBContext())
            {
                var clients = context.Clients
                    .Select(c => new { c.ClientID, FullName = c.FirstName + " " + c.LastName })
                    .ToList();
                ClientComboBox.ItemsSource = clients;
                ClientComboBox.DisplayMemberPath = "FullName";
                ClientComboBox.SelectedValuePath = "ClientID";
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new GSDBContext())
                {
                    // Load the existing sale
                    var sale = context.Sales
                        .Include(s => s.Product)
                        .Include(s => s.Client)
                        .FirstOrDefault(s => s.SaleID == _saleId);

                    if (sale != null)
                    {
                        // Retrieve selected entities
                        var selectedProductID = (int?)ProductComboBox.SelectedValue;
                        var selectedClientID = (int?)ClientComboBox.SelectedValue;

                        if (selectedProductID.HasValue && selectedClientID.HasValue)
                        {
                            var selectedProduct = context.Products.FirstOrDefault(p => p.ProductID == selectedProductID.Value);
                            var selectedClient = context.Clients.FirstOrDefault(c => c.ClientID == selectedClientID.Value);

                            if (selectedProduct != null && selectedClient != null)
                            {
                                // Update sale entity
                                sale.Product = selectedProduct;
                                sale.Client = selectedClient;
                                sale.QuantitySold = int.TryParse(QuantitySoldTextBox.Text, out int quantity) ? quantity : 0;
                                sale.Status = StatusComboBox.SelectedItem as string;

                                // Update inventory based on status
                                if (sale.Status == "Cancelled")
                                {
                                    // Add quantity back to inventory
                                    var inventoryItem = context.Inventory
                                        .FirstOrDefault(i => i.ProductID == sale.Product.ProductID);

                                    if (inventoryItem != null)
                                    {
                                        inventoryItem.QuantityInStock += sale.QuantitySold;
                                        inventoryItem.LastRestockDate = DateTime.Now;
                                    }
                                }
                                else if (sale.Status == "Delivered")
                                {
                                    // Deduct quantity from inventory
                                    var inventoryItem = context.Inventory
                                        .FirstOrDefault(i => i.ProductID == sale.Product.ProductID);

                                    if (inventoryItem != null)
                                    {
                                        inventoryItem.QuantityInStock -= sale.QuantitySold;
                                        inventoryItem.LastRestockDate = DateTime.Now;
                                    }
                                }

                                // Save changes
                                context.SaveChanges();
                                MessageBox.Show("Sale updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Selected Product or Client not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Product or Client is not selected correctly.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sale not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
