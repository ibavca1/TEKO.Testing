using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.Core.PersonAggregate;
namespace TEKO.Testing.UseCases.Person.Add;

public class AddPersonHandler : ICommandHandler<AddPersonCommand, Result<int>>
{
  private readonly IRepository<Core.PersonAggregate.Person> _repository;

  public AddPersonHandler(IRepository<Core.PersonAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(AddPersonCommand request,
    CancellationToken cancellationToken)
  {
    var newPerson = new Core.PersonAggregate.Person();
    
    var createdItem = await _repository.AddAsync(newPerson, cancellationToken);

    return createdItem.Id;
  }
}
