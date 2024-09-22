using System;
using System.Collections.Generic;

namespace WpfAppGlobalShoes.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }

        // Navigation Property (if clients have sales)
        public ICollection<Sale> Sales { get; set; }
    }
}
