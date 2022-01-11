using Mc2.CrudTest.Presentation.Server.Core.Domain;
using Mc2.CrudTest.Presentation.Server.Core.Repositories;

namespace Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Commands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public string Firstname { get; }

        public string Lastname { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

        public string BankAccountNumber { get; }

        public DateTime DateOfBirth { get; }

        public CreateCustomerCommand(
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

        internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
        {
            private readonly ICustomerRepository _customerRepository;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = new Customer(
                    request.Firstname,
                    request.Lastname,
                    request.PhoneNumber,
                    request.Email,
                    request.BankAccountNumber,
                    request.DateOfBirth);

                await _customerRepository.AddAsync(customer);

                return customer;
            }
        }
    }
}
