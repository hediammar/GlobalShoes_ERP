using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfAppGlobalShoes.CHARGES;
using WpfAppGlobalShoes.Context;

namespace WpfAppGlobalShoes
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool isSidebarMinimized = false; // Track if sidebar is minimized

        public string SidebarWidth { get; set; }
        public Visibility SidebarTextVisibility { get; set; }

        private string _loggedInEmployeeName;
        public string LoggedInEmployeeName
        {
            get { return _loggedInEmployeeName; }
            set
            {
                _loggedInEmployeeName = value;
                OnPropertyChanged("LoggedInEmployeeName");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            DataContext = this;

            // Default expanded state
            SidebarWidth = "300";
            SidebarTextVisibility = Visibility.Visible;

            // Fetch the employee's name based on the session
            LoadLoggedInEmployeeName();
        }

        private void LoadLoggedInEmployeeName()
        {
            // Assuming you have a session that stores the EmployeeID
            int employeeId = Session.CurrentUserId; // Replace with actual session code

            // Retrieve the employee's name based on EmployeeID from the database
            var employeeName = GetEmployeeNameById(employeeId); // Replace with your method to fetch name
            LoggedInEmployeeName = employeeName;
        }

        private string GetEmployeeNameById(int employeeId)
        {
            // This is a placeholder for database access logic
            // Replace it with your actual code to fetch the name from the DB
            using (var db = new GSDBContext()) // Replace with your DbContext
            {
                var employee = db.Employees.Find(employeeId);
                return employee != null ? $"{employee.FirstName} {employee.LastName}" : "Unknown";
            }
        }

        // Implement INotifyPropertyChanged to update the UI when the name changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ToggleSidebar_Click(object sender, RoutedEventArgs e)
        {
            if (isSidebarMinimized)
            {
                // Expand the sidebar
                Sidebar.Width = 200; // Set the width to expanded state
                SidebarTextVisibility = Visibility.Visible; // Show text
            }
            else
            {
                // Minimize the sidebar
                Sidebar.Width = 80; // Set the width to minimized state
                SidebarTextVisibility = Visibility.Collapsed; // Hide text
            }

            isSidebarMinimized = !isSidebarMinimized; // Toggle the state

            // Refresh the sidebar text visibility binding
            OnPropertyChanged(nameof(SidebarTextVisibility));
        }

        private void OverviewButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Overview Content
        }

        private void HumanResourcesButton_Click(object sender, RoutedEventArgs e)
        {
            // Load employee details view
            var employeeView = new EmployeeView(); // Assuming EmployeeView is a UserControl
            MainContent.Content = employeeView;
        }

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            var InvView = new InventoryView(); // Assuming InventoryView is a UserControl
            MainContent.Content = InvView;
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Sales Content
            var SaleView = new SalesView(); // Assuming SalesView is a UserControl
            MainContent.Content = SaleView;
        }

        private void ChargesButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Charges Content
            var ChargeView = new ChargesView(); // Assuming ChargesView is a UserControl
            MainContent.Content = ChargeView;
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Clients Content
            var ClientView = new ClientView(); // Assuming ChargesView is a UserControl
            MainContent.Content = ClientView;
        }
    }
}
