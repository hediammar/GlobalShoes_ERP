using System;
using System.Linq;
using System.Windows;
using WpfAppGlobalShoes.Context;
using WpfAppGlobalShoes.Models;

namespace WpfAppGlobalShoes
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            // Validate the username and password
            if (ValidateUser(username, password))
            {
                // If validation is successful, create a new session
                // Assuming Session is a class that holds session information
                Session.CurrentUserId = GetUserId(username);

                // Open the main window and close the login window
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
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
                    // For security reasons, ensure that passwords are hashed and compared securely
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
                    // Retrieve the UserID for the given username
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
    }
}
