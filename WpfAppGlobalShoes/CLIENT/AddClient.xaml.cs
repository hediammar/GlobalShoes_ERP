using System;
using System.Windows;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class AddClient : Window
    {
        public Client Client { get; set; }

        public AddClient(Client client = null)
        {
            InitializeComponent();
            Client = client ?? new Client();
            DataContext = Client;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new GSDBContext())
                {
                    if (Client.ClientID == 0) // New client
                    {
                        context.Clients.Add(Client);
                    }
                    else // Update existing client
                    {
                        context.Clients.Update(Client);
                    }

                    await context.SaveChangesAsync();
                    MessageBox.Show("Client saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                DialogResult = true; // Optionally set the DialogResult
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the client: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
