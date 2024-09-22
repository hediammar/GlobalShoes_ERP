using System;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes.CHARGES
{
    public partial class AddChargeWindow : Window
    {
        private readonly GSDBContext _context;
        private readonly ChargesView _chargesView; // Reference to ChargesView

        public AddChargeWindow(ChargesView chargesView)
        {
            InitializeComponent();
            _context = new GSDBContext();
            _chargesView = chargesView; // Initialize ChargesView
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(ChargeTypeTextBox.Text) ||
                    string.IsNullOrWhiteSpace(AmountTextBox.Text) ||
                    ChargeDatePicker.SelectedDate == null ||
                    PaidStatusComboBox.SelectedItem == null ||
                    DueDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Create a new Charge object
                var newCharge = new Charge
                {
                    ChargeType = ChargeTypeTextBox.Text,
                    Amount = decimal.Parse(AmountTextBox.Text),
                    ChargeDate = (DateTime)ChargeDatePicker.SelectedDate,
                    Description = DescriptionTextBox.Text,
                    PaidStatus = (PaidStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    DueDate = (DateTime)DueDatePicker.SelectedDate,
                    EmployeeID = Session.CurrentUserId // Assuming you have a Session object that tracks the logged-in user
                };

                // Add the charge to the database
                _context.Charges.Add(newCharge);
                _context.SaveChanges();

                MessageBox.Show("Charge added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the ChargesView DataGrid after adding the charge
                _chargesView.LoadCharges();

                // Close the window
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the window if cancel is clicked
        }
    }
}
