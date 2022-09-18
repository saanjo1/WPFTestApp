using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
            People = new HashSet<Person>();
        }

        public Guid Id { get; set; }
        public string? ClientNumber { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? TaxNumber { get; set; }
        public string? CityAndPostCode { get; set; }
        public string? BankNumber { get; set; }
        public string? IdNumber { get; set; }
        public decimal Discount { get; set; }
        public bool IsDeleted { get; set; }
        public string? ExtraNote { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
