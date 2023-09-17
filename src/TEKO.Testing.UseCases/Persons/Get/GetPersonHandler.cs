using Ardalis.Result;
using Ardalis.SharedKernel;

using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.Core.PersonAggregate.Specifications;


namespace TEKO.Testing.UseCases.Persons.Get;


public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
  private readonly IReadRepository<Core.PersonAggregate.Person> _repository;

  public GetPersonHandler(IReadRepository<Core.PersonAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpec(request.PersonId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new PersonDTO(entity.Id, entity.Name!, entity.Surname!, entity.Patronymic!, 0,0, new Appointment());
  }
}
