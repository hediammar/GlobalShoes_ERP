using System.Windows;
using System.Windows.Controls;
using WpfAppGlobalShoes.Context;

namespace WpfAppGlobalShoes.CHARGES
{
    public partial class EditChargeWindow : Window
    {
        private Charge _charge;
        private ChargesView _chargesView; // Reference to ChargesView

        public EditChargeWindow(Charge charge, ChargesView chargesView)
        {
            InitializeComponent();
            _charge = charge;
            _chargesView = chargesView; // Initialize ChargesView

            // Populate fields with charge data
            ChargeTypeTextBox.Text = _charge.ChargeType;
            AmountTextBox.Text = _charge.Amount.ToString();
            ChargeDatePicker.SelectedDate = _charge.ChargeDate;
            DescriptionTextBox.Text = _charge.Description;

            // Populate PaidStatusComboBox and select the current value
            PaidStatusComboBox.ItemsSource = new string[] { "Paid", "Pending"}; // Adjust according to your statuses
            PaidStatusComboBox.SelectedItem = _charge.PaidStatus; // Set the correct value
            DueDatePicker.SelectedDate = _charge.DueDate;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update charge properties with user input
            _charge.ChargeType = ChargeTypeTextBox.Text;
            _charge.Amount = decimal.Parse(AmountTextBox.Text);
            _charge.ChargeDate = ChargeDatePicker.SelectedDate.Value;
            _charge.Description = DescriptionTextBox.Text;

            // Safely retrieve the selected paid status
            if (PaidStatusComboBox.SelectedItem != null)
            {
                _charge.PaidStatus = PaidStatusComboBox.SelectedItem.ToString();
            }

            _charge.DueDate = DueDatePicker.SelectedDate;

            using (var context = new GSDBContext())
            {
                context.Charges.Update(_charge);
                context.SaveChanges();
            }

            // Refresh the ChargesView DataGrid
            _chargesView.LoadCharges();

            DialogResult = true;
            Close();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
