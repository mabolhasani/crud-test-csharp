using Mc2.CrudTest.Presentation.Server.Application.Common;
using Mc2.CrudTest.Presentation.Server.Application.Common.Exceptions;
using Mc2.CrudTest.Presentation.Server.Core.Domain;
using Mc2.CrudTest.Presentation.Server.Core.Repositories;

namespace Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Commands
{
    public class EditCustomerCommand : IRequest<Customer>
    {
        public int Id { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string PhoneNumber { get; }

        public string Email { get; }

        public string BankAccountNumber { get; }

        public DateTime DateOfBirth { get; }

        public EditCustomerCommand(
            int id,
            string firstname,
            string lastname,
            string phoneNumber,
            string email,
            string bankAccountNumber,
            DateTime dataOfBirth)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
            DateOfBirth = dataOfBirth;
        }

        internal sealed class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, Customer>
        {
            private readonly ICustomerRepository _customerRepository;

            public EditCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<Customer> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id);

                if (customer is not { })
                {
                    throw new NotFoundException(ErrorMessages.CustomerNotFound);
                }

                customer.Edit(
                    request.Firstname,
                    request.Lastname,
                    request.PhoneNumber,
                    request.Email,
                    request.BankAccountNumber,
                    request.DateOfBirth);

                await _customerRepository.UpdateAsync(customer);

                return customer;
            }
        }
    }
}
