using System.Windows;
using WpfAppGlobalShoes.CHARGES;

namespace WpfAppGlobalShoes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            {
                //ContentArea.Content = new InventoryView();
                var InvView = new InventoryView(); // Assuming EmployeeView is a UserControl
                MainContent.Content = InvView;
            }
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Sales Content
            var SaleView = new SalesView(); // Assuming EmployeeView is a UserControl
            MainContent.Content = SaleView;
        }

        private void ChargesButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Charges Content
            var ChargeView = new ChargesView(); // Assuming EmployeeView is a UserControl
            MainContent.Content = ChargeView;
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            // Load Clients Content
        }
    }
}
