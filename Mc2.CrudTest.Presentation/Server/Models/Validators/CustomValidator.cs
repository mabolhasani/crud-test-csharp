namespace Mc2.CrudTest.Presentation.Server.Models.Validators;

public static class CustomValidator
{
    private const int PhoneNumberMinimumLength = 7;
    private const int PhoneNumberMaximumLength = 15;

    public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        var rule = ruleBuilder
            .NotEmpty()
            .Length(PhoneNumberMinimumLength, PhoneNumberMaximumLength);

        return rule.Must(p =>
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                return phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(p.ToString(), "IR"));
            }
            catch (NumberParseException ex)
            {
                //omit the exception and return false 
                return false;
            }
        })
            .WithMessage("Phone number format is wrong.");
    }
}
