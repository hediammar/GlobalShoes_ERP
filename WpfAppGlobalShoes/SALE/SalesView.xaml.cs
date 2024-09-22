using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();
            LoadSalesData();
        }

        private void LoadSalesData()
        {
            using (var context = new GSDBContext())
            {
                var salesData = context.Sales
                    .Include(s => s.Product)
                    .Include(s => s.Client)
                    .ToList();
                SalesDataGrid.ItemsSource = salesData;
            }
        }

        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            var addSaleWindow = new AddSaleWindow();
            addSaleWindow.ShowDialog();
            LoadSalesData();  // Refresh data after adding
        }

        private void EditSale_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected in the DataGrid
            if (SalesDataGrid.SelectedItem is Sale selectedSale)
            {
                var editSaleWindow = new EditSaleWindow(selectedSale.SaleID);
                editSaleWindow.ShowDialog();
                LoadSalesData();  // Refresh data after editing
            }
            else
            {
                MessageBox.Show("Please select a sale to edit.", "Edit Sale", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteSale_Click(object sender, RoutedEventArgs e)
        {
            // Check if an item is selected in the DataGrid
            if (SalesDataGrid.SelectedItem is Sale selectedSale)
            {
                using (var context = new GSDBContext())
                {
                    context.Sales.Remove(selectedSale);
                    context.SaveChanges();
                }
                LoadSalesData();  // Refresh data after deleting
            }
            else
            {
                MessageBox.Show("Please select a sale to delete.", "Delete Sale", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
