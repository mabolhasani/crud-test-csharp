using Mc2.CrudTest.Presentation.Server.Core.Domain;

namespace Mc2.CrudTest.Presentation.Server.Models.CustomerModels
{
    public class CustomerModel
    {
        public int Id { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

        public string BankAccountNumber { get; }

        public DateTime DateOfBirth { get; }

        public CustomerModel(Customer customer)
        {
            Id = customer.Id;
            Firstname = customer.Firstname;
            Lastname = customer.Lastname;
            PhoneNumber = customer.PhoneNumber;
            Email = customer.Email;
            BankAccountNumber = customer.BankAccountNumber;
            DateOfBirth = customer.DateOfBirth;
        }
    }
}
