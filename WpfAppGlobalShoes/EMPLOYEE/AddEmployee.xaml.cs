using System.Windows;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class AddEmployee : Window
    {
        public Employee Employee { get; set; }

        public AddEmployee(Employee employee = null)
        {
            InitializeComponent();
            Employee = employee ?? new Employee();
            DataContext = Employee;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new GSDBContext())
            {
                if (Employee.EmployeeID == 0) // New employee
                {
                    context.Employees.Add(Employee);
                }
                else // Update existing employee
                {
                    context.Employees.Update(Employee);
                }

                await context.SaveChangesAsync();
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
