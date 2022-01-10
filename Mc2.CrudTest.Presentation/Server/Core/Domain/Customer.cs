namespace Mc2.CrudTest.Presentation.Server.Core.Domain;

public class Customer : BaseEntity
{
    public string Firstname { get; private set; }

    public string Lastname { get; private set; }

    public DateTime DateOfBirth { get; private set; }

    public string PhoneNumber { get; private set; }

    public string Email { get; private set; }

    public string BankAccountNumber { get; private set; }
}

