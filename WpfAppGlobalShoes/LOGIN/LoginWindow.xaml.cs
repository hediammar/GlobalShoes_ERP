using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation; // Add this for Storyboard
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            // Set window to full screen
            this.WindowState = WindowState.Maximized;
             // Remove window borders if desired
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            // Validate the username and password
            if (ValidateUser(username, password))
            {
                // If validation is successful, create a new session
                Session.CurrentUserId = GetUserId(username);

                // Trigger the fade-out animation
                StartFadeOutAnimation();
            }
            else
            {
                // Show an error message if validation fails
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateUser(string username, string password)
        {
            try
            {
                using (var context = new GSDBContext())
                {
                    // Check if there's a user with the given username and password
                    return context.User.Any(user => user.Username == username && user.Password == password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while validating the user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private int GetUserId(string username)
        {
            try
            {
                using (var context = new GSDBContext())
                {
                    // Retrieve the EmployeeID for the given username
                    return context.User.Where(user => user.Username == username)
                                       .Select(user => user.EmployeeID)
                                       .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the user ID: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0; // Assuming 0 indicates an error or no user found
            }
        }

        // Method to start fade-out animation after a successful login
        private void StartFadeOutAnimation()
        {
            // Retrieve the fade-out storyboard defined in XAML
            Storyboard fadeOutStoryboard = (Storyboard)FindResource("FadeOutStoryboard");

            // Add a completed event handler to load the main window after animation
            fadeOutStoryboard.Completed += FadeOutStoryboard_Completed;

            // Begin the animation
            fadeOutStoryboard.Begin(this);
        }

        // Event handler for when the fade-out animation completes
        private async void FadeOutStoryboard_Completed(object sender, EventArgs e)
        {
            // Show the loading window after fade-out
            LoadingWindow loadingWindow = new LoadingWindow();
            loadingWindow.Show();

            // Simulate a time-consuming operation
            await Task.Delay(5000); // Replace with your actual loading logic

            // Close the loading window after the simulated loading process
            loadingWindow.Close();

            // Open the main application window
            var mainWindow = new MainWindow();
            mainWindow.Show();

            // Close the login window
            this.Close();
        }
    }
}
