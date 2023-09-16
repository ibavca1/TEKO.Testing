using FastEndpoints;
using MediatR;
using Ardalis.Result;
using TEKO.Testing.UseCases.Contributors.Get;
using TEKO.Testing.Web.Endpoints.PersonsEndpoints;
using TEKO.Testing.Web.ContributorEndpoints;
using TEKO.Testing.UseCases.Persons.Get;
using TEKO.Testing.Web.PersonsEndpoints;

namespace TEKO.Testing.Web.PersonEndpoints;

/// <summary>
/// Get a Contributor by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Contributor record.
/// </remarks>
public class GetById : Endpoint<GetPersonByIdRequest, PersonRecord>
{
  private readonly IMediator _mediator;

  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetPersonByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetPersonByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetPersonQuery(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      //TODO: Info not full
      Response = new PersonRecord(result.Value.Id, result.Value.Name, result.Value.Surname, result.Value.Patronymic, 0 , 0, 0);
    }
  }
}
