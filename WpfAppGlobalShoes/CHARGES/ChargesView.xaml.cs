using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;
using WpfAppGlobalShoes.CHARGES;

namespace WpfAppGlobalShoes.CHARGES
{
    public partial class ChargesView : UserControl
    {
        private List<Charge> _charges;

        public ChargesView()
        {
            InitializeComponent();
            LoadCharges();
        }

        // Method to load charges from the database
        public void LoadCharges()
        {
            using (var context = new GSDBContext())
            {
                _charges = context.Charges.ToList();
                ChargesDataGrid.ItemsSource = _charges;
            }
        }

        // Filtering the charges based on Charge Type ComboBox
        private void ChargeTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterCharges();
        }

        // Sorting charges based on Sort By ComboBox
        private void SortByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortCharges();
        }

        // Filtering charges by selected Charge Type
        private void FilterCharges()
        {
            string selectedType = (ChargeTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var filteredCharges = _charges.AsQueryable();

            if (selectedType != "All")
            {
                filteredCharges = filteredCharges.Where(c => c.ChargeType == selectedType);
            }

            ChargesDataGrid.ItemsSource = filteredCharges.ToList();
            SortCharges(); // Apply sorting after filtering
        }

        // Sorting charges by selected sorting option
        private void SortCharges()
        {
            string selectedSortOrder = (SortByComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            var sortedCharges = ChargesDataGrid.ItemsSource.Cast<Charge>();

            switch (selectedSortOrder)
            {
                case "Amount Ascending":
                    sortedCharges = sortedCharges.OrderBy(c => c.Amount);
                    break;
                case "Amount Descending":
                    sortedCharges = sortedCharges.OrderByDescending(c => c.Amount);
                    break;
                case "Date Ascending":
                    sortedCharges = sortedCharges.OrderBy(c => c.ChargeDate);
                    break;
                case "Date Descending":
                    sortedCharges = sortedCharges.OrderByDescending(c => c.ChargeDate);
                    break;
            }

            ChargesDataGrid.ItemsSource = sortedCharges.ToList();
        }

        // Open AddChargeWindow, refresh list after adding a charge
        private void AddChargeButton_Click(object sender, RoutedEventArgs e)
        {
            var addChargeWindow = new AddChargeWindow(this);
            if (addChargeWindow.ShowDialog() == true)
            {
                LoadCharges(); // Refresh the list after adding
            }
        }

        // Open EditChargeWindow, refresh list after editing a charge
        private void EditChargeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ChargesDataGrid.SelectedItem is Charge selectedCharge)
            {
                var editChargeWindow = new EditChargeWindow(selectedCharge, this); // Pass ChargesView for refreshing
                if (editChargeWindow.ShowDialog() == true)
                {
                    LoadCharges(); // Refresh the list after editing
                }
            }
            else
            {
                MessageBox.Show("Please select a charge to edit.");
            }
        }

        // Delete the selected charge and refresh the list
        private void DeleteChargeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ChargesDataGrid.SelectedItem is Charge selectedCharge)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this charge?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new GSDBContext())
                    {
                        context.Charges.Remove(selectedCharge);
                        context.SaveChanges();
                    }
                    LoadCharges(); // Refresh the list after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select a charge to delete.");
            }
        }
    }
}
