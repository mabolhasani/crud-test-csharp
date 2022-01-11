using Mc2.CrudTest.Presentation.Server.Core.Domain;
using Mc2.CrudTest.Presentation.Server.Core.Repositories;

namespace Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Queries;

public class GetAllCustomersQuery : IRequest<IReadOnlyList<Customer>>
{
    internal sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IReadOnlyList<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllAsync();
        }
    }
}

