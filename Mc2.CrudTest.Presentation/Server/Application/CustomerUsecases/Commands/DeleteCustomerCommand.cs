using Mc2.CrudTest.Presentation.Server.Application.Common;
using Mc2.CrudTest.Presentation.Server.Application.Common.Exceptions;
using Mc2.CrudTest.Presentation.Server.Core.Repositories;

namespace Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Commands;

public class DeleteCustomerCommand : IRequest
{
    public int CustomerId { get; }

    public DeleteCustomerCommand(int customerId)
    {
        CustomerId = customerId;
    }

    internal sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer is not { })
            {
                throw new NotFoundException(ErrorMessages.CustomerNotFound);
            }

            await _customerRepository.DeleteAsync(customer);

            return Unit.Value;
        }
    }
}

