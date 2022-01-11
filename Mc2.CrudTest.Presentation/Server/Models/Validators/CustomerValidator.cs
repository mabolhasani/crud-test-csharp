using Mc2.CrudTest.Presentation.Server.Models.CustomerModels;

namespace Mc2.CrudTest.Presentation.Server.Models.Validators;

public class CustomerValidator : AbstractValidator<CreateEditCustomerModel>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Firstname)
            .NotEmpty()
            .Length(2, 200);

        RuleFor(c => c.Lastname)
            .NotEmpty()
            .Length(2, 200);

        RuleFor(c => c.PhoneNumber)
            .PhoneNumber();

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(c => c.DateOfBirth)
            .NotEmpty();

        //TODO: What is a valid Bank Account Number?? :)
        RuleFor(c => c.BankAccountNumber)
            .NotEmpty()
            .Length(5, 100);
    }
}

