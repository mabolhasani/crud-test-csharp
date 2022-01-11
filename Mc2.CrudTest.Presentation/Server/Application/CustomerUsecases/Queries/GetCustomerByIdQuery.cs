using Mc2.CrudTest.Presentation.Server.Application.Common;
using Mc2.CrudTest.Presentation.Server.Application.Common.Exceptions;
using Mc2.CrudTest.Presentation.Server.Core.Domain;
using Mc2.CrudTest.Presentation.Server.Core.Repositories;

namespace Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Queries;

public class GetCustomerByIdQuery : IRequest<Customer>
{
    public int CustomerId { get; }

    public GetCustomerByIdQuery(int customerId)
    {
        CustomerId = customerId;
    }

    internal sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);

            if (customer is not { })
            {
                throw new NotFoundException(ErrorMessages.CustomerNotFound);
            }

            return customer;
        }
    }
}

