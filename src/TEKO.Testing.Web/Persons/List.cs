using FastEndpoints;
using MediatR;
using TEKO.Testing.UseCases.Persons.List;
using TEKO.Testing.Web.Persons;

namespace TEKO.Testing.Web.ContributorEndpoints;

/// <summary>
/// List all Persons
/// </summary>
/// <remarks>
/// List all Persons - returns a ContributorListResponse containing the Persons.
/// </remarks>
public class ListPersons : EndpointWithoutRequest<PersonListResponse>
{
  private readonly IMediator _mediator;

  public ListPersons(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/Persons");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListPersonsQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new PersonListResponse
      {
        Persons = result.Value.Select(c => new ListPersonRecord(c.Id, c.Name, c.Surname, c.Patronymic)).ToList()
      };
    }
  }
}
