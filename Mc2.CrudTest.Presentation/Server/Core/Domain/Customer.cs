namespace Mc2.CrudTest.Presentation.Server.Core.Domain;

public class Customer : BaseEntity
{
    public string Firstname { get; private set; }

    public string Lastname { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; private set; }

    public string BankAccountNumber { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    private Customer() { }

    public Customer(
        string firstname,
        string lastname,
        string phoneNumber,
        string email,
        string bankAccountNumber,
        DateTime dataOfBirth)
    {
        Firstname = firstname;
        Lastname = lastname;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        DateOfBirth = dataOfBirth;
    }

    public Customer Edit(
        string firstname,
        string lastname,
        string phoneNumber,
        string email,
        string bankAccountNumber,
        DateTime dataOfBirth)
    {
        Firstname = firstname;
        Lastname = lastname;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        DateOfBirth = dataOfBirth;

        return this;
    }
}

