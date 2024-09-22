using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
            LoadEmployeeData();
        }

        private async void LoadEmployeeData()
        {
            using (var context = new GSDBContext())
            {
                // Retrieve employee data from the database
                List<Employee> employees = await context.Employees.ToListAsync();

                // Bind data to the DataGrid
                EmployeeDataGrid.ItemsSource = employees;
            }
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new AddEmployee();
            if (addEmployeeWindow.ShowDialog() == true)
            {
                LoadEmployeeData(); // Refresh the employee list after adding a new employee
            }
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                var editEmployeeWindow = new AddEmployee(selectedEmployee);
                if (editEmployeeWindow.ShowDialog() == true)
                {
                    LoadEmployeeData(); // Refresh the employee list after editing
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        private async void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                var result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new GSDBContext())
                    {
                        context.Employees.Remove(selectedEmployee);
                        await context.SaveChangesAsync();
                        LoadEmployeeData(); // Refresh the employee list after deletion
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }
    }
}
