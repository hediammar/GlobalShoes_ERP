using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;

namespace WpfAppGlobalShoes
{
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
            LoadInventoryData();
        }

        private async void LoadInventoryData()
        {
            using (var context = new GSDBContext())
            {
                var inventoryData = from product in context.Products
                                    join inventory in context.Inventory
                                    on product.ProductID equals inventory.ProductID
                                    select new
                                    {
                                        product.ProductID,
                                        product.ProductName,
                                        product.Category,
                                        product.Size,
                                        product.Color,
                                        product.Material,
                                        product.Price,
                                        product.ManufacturingDate,
                                        product.WarrantyPeriod,
                                        inventory.QuantityInStock,
                                        inventory.LastRestockDate,
                                        inventory.MinimumStockLevel
                                    };

                InventoryDataGrid.ItemsSource = await inventoryData.ToListAsync();
            }
        }

        private void UpdateQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem is not null)
            {
                var selectedItem = InventoryDataGrid.SelectedItem;
                var productName = selectedItem.GetType().GetProperty("ProductName")?.GetValue(selectedItem, null).ToString();
                var currentQuantity = (int)selectedItem.GetType().GetProperty("QuantityInStock")?.GetValue(selectedItem, null);

                var updateWindow = new UpdateQuantityWindow(productName, currentQuantity);

                if (updateWindow.ShowDialog() == true)
                {
                    using (var context = new GSDBContext())
                    {
                        var productId = (int)selectedItem.GetType().GetProperty("ProductID")?.GetValue(selectedItem, null);
                        var inventoryItem = context.Inventory.SingleOrDefault(i => i.ProductID == productId);
                        if (inventoryItem != null)
                        {
                            inventoryItem.QuantityInStock += updateWindow.NewQuantity;
                            inventoryItem.LastRestockDate = DateTime.Now;
                            context.SaveChanges();
                        }
                    }
                    LoadInventoryData();
                }
            }
            else
            {
                MessageBox.Show("Please select a product row.");
            }
        }
    }
}
