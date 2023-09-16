using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.Core.ContributorAggregate;
using TEKO.Testing.Core.ContributorAggregate.Specifications;
using TEKO.Testing.Core.PeopleAggregate;
using TEKO.Testing.Core.PersonAggregate.Specifications;
using TEKO.Testing.UseCases.Persons;
using TEKO.Testing.UseCases.Persons.Get;

namespace TEKO.Testing.UseCases.Persons.Get;


public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
  private readonly IReadRepository<Core.PeopleAggregate.Person> _repository;

  public GetPersonHandler(IReadRepository<Core.PeopleAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpec(request.PersonId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new PersonDTO(entity.Id, entity.Name!, entity.Surname!, entity.Patronymic!);
  }
}
