using System.Windows;
using WpfAppGlobalShoes.CHARGES;

namespace WpfAppGlobalShoes
{
    public partial class MainWindow : Window
    {
        private bool isSidebarMinimized = false; // Track if sidebar is visible

        public string SidebarWidth { get; set; }
        public string OverviewButtonText { get; set; }
        public string HRButtonText { get; set; }
        public string InventoryButtonText { get; set; }
        public string SalesButtonText { get; set; }
        public string ChargesButtonText { get; set; }
        public string ClientsButtonText { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            DataContext = this;

            // Default expanded state
            SidebarWidth = "120";
            SetButtonText();
        }

        private void ToggleSidebar_Click(object sender, RoutedEventArgs e)
        {
            if (isSidebarMinimized)
            {
                // Expand the sidebar
                SidebarColumn.Width = new GridLength(200); ; // Set the sidebar column width back to its original value
                Sidebar.Width = 200; // Set the sidebar width back to its original value
            }
            else
            {
                // Minimize the sidebar
                SidebarColumn.Width = new GridLength(50); ; // Set the sidebar column width to a minimized value
                Sidebar.Width = 50; // Set the sidebar width to a minimized value
            }

            isSidebarMinimized = !isSidebarMinimized; // Toggle the state
        }

        private void SetButtonText()
        {
            OverviewButtonText = "Overview";
            HRButtonText = "HR";
            InventoryButtonText = "Inventory";
            SalesButtonText = "Sales";
            ChargesButtonText = "Charges";
            ClientsButtonText = "Clients";
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
        }
    }
}
