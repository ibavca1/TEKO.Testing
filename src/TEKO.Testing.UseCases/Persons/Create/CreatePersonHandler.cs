using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Persons.Create;

public class CreatePersonHandler:ICommandHandler<CreatePersonCommand, Result<int>>
{
  private readonly IRepository<Core.PersonAggregate.Person> _repository;

  public CreatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
  {
    _repository = repository;
  }
  public async Task<Result<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
  {
    var newPerson = new Core.PersonAggregate.Person
    {
      Name = request.Name,
      Surname = request.Surname,
      Patronymic = request.Patronymic
    };
    var createdPerson = await _repository.AddAsync(newPerson);
    return createdPerson.Id;
  }
}
