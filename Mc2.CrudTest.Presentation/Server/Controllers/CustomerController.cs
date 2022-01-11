using Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Commands;
using Mc2.CrudTest.Presentation.Server.Application.CustomerUsecases.Queries;
using Mc2.CrudTest.Presentation.Server.Models.CustomerModels;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

public class CustomerController : BaseController
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

        return Ok(new CustomerModel(customer));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateEditCustomerModel createCustomer)
    {
        var customerModel = new CreateCustomerCommand(
            createCustomer.Firstname,
            createCustomer.Lastname,
            createCustomer.PhoneNumber,
            createCustomer.Email,
            createCustomer.BankAccountNumber,
            createCustomer.DateOfBirth);

        var customer = await _mediator.Send(customerModel);

        return Created(
            Url.Action("Get", "Customer", new { customer.Id }),
            new CustomerModel(customer)
            );
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CustomerModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> List()
    {
        var customers = await _mediator.Send(new GetAllCustomersQuery());

        return Ok(customers.Select(c => new CustomerModel(c)));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Edit(int id, CreateEditCustomerModel editCustomer)
    {
        var editCustomerCommand = new EditCustomerCommand(
            id,
            editCustomer.Firstname,
            editCustomer.Lastname,
            editCustomer.PhoneNumber,
            editCustomer.Email,
            editCustomer.BankAccountNumber,
            editCustomer.DateOfBirth);

        var customer = await _mediator.Send(editCustomerCommand);

        return Ok(new CustomerModel(customer));
    }
}

