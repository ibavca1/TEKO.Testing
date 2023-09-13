using FastEndpoints;
using FluentValidation;
using TEKO.Testing.Web.Endpoints.PersonsEndpoints;

namespace TEKO.Testing.Web.Endpoints.Persons.Endpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetPersonValidator : Validator<GetPersonByIdRequest>
{
  public GetPersonValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
