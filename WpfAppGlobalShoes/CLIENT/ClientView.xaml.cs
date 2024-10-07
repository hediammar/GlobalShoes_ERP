using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class ClientView : UserControl
    {
        public ClientView()
        {
            InitializeComponent();
            LoadClientData();
        }

        private async void LoadClientData()
        {
            using (var context = new GSDBContext())
            {
                // Retrieve employee data from the database
                List<Client> clients = await context.Clients.ToListAsync();

                // Bind data to the DataGrid
                ClientDataGrid.ItemsSource = clients;
            }
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClient();
            if (addClientWindow.ShowDialog() == true)
            {
                LoadClientData(); // Refresh the employee list after adding a new employee
            }
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientDataGrid.SelectedItem is Client selectedClient)
            {
                var editClientWindow = new AddClient(selectedClient);
                if (editClientWindow.ShowDialog() == true)
                {
                    LoadClientData(); // Refresh the employee list after editing
                }
            }
            else
            {
                MessageBox.Show("Please select a Client to edit.");
            }
        }

        private async void BtnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientDataGrid.SelectedItem is Client selectedClient)
            {
                var result = MessageBox.Show("Are you sure you want to delete this Client?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new GSDBContext())
                    {
                        context.Clients.Remove(selectedClient);
                        await context.SaveChangesAsync();
                        LoadClientData(); // Refresh the employee list after deletion
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an Client to delete.");
            }
        }
    }
}
