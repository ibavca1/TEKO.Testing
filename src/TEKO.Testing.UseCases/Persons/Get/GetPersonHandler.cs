using Ardalis.GuardClauses;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Ardalis.Specification;
using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.Core.PersonAggregate.Specifications;


namespace TEKO.Testing.UseCases.Persons.Get;


public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDto>>
{
  private readonly IReadRepository<Core.PersonAggregate.Person> _repository;

  public GetPersonHandler(IReadRepository<Core.PersonAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<PersonDto>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    var specPerson = new PersonByIdSpec(request.PersonId);
    var person = await _repository.FirstOrDefaultAsync(specPerson, cancellationToken);

    if (person?.Appointment != null)
    {
      return new PersonDto(
        person.Id,
        person.Name!,
        person.Surname!,
        person.Patronymic!,
        person.Gender!,
        person.Age,
        person.Appointment,
        person.TimeOff = new List<TimeOff>());
    }
    else
    {
      return Result.NotFound();
    }
  }
}
