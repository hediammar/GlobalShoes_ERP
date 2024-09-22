namespace WpfAppGlobalShoes.Models
{
    public class User
    {
        public int UserID { get; set; }
        public int EmployeeID { get; set; } // Foreign key to Employee
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Optional: Admin, Sales, etc.

        public Employee Employee { get; set; } // Navigation property
    }
}
