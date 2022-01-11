using Mc2.CrudTest.Presentation.Server.Core.Domain;
using Mc2.CrudTest.Presentation.Server.Core.Repositories;
using Mc2.CrudTest.Presentation.Server.Core.Repositories.Base;
using Mc2.CrudTest.Presentation.Server.Infrastructure.Data;
using Mc2.CrudTest.Presentation.Server.Infrastructure.Repositories.Base;

namespace Mc2.CrudTest.Presentation.Server.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository, IService
{
    public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext) { }
}

