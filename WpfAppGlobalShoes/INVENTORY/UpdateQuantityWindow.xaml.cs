using System.Windows;

namespace WpfAppGlobalShoes
{
    public partial class UpdateQuantityWindow : Window
    {
        public int NewQuantity { get; private set; }

        public UpdateQuantityWindow(string productName, int currentQuantity)
        {
            InitializeComponent();
            ProductNameText.Text = $"Product: {productName}";
            CurrentQuantityText.Text = $"Current Quantity: {currentQuantity}";
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NewQuantityTextBox.Text, out int newQuantity))
            {
                NewQuantity = newQuantity;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
            }
        }
    }
}
