using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.Core.ContributorAggregate;
using TEKO.Testing.UseCases.Persons;

namespace TEKO.Testing.UseCases.Person.Add;

public class AddPersonHandler : ICommandHandler<AddPersonCommand, Result<int>>
{
  private readonly IRepository<Core.PeopleAggregate.Person> _repository;

  public AddPersonHandler(IRepository<Core.PeopleAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(AddPersonCommand request,
    CancellationToken cancellationToken)
  {
    var newPerson = new Core.PeopleAggregate.Person();
    
    var createdItem = await _repository.AddAsync(newPerson, cancellationToken);

    return createdItem.Id;
  }
}
