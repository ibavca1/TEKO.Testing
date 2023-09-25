using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Contributors.Create;

public class CreatePersonHandler : ICommandHandler<CreatePersonCommand, Result<int>>
{
  private readonly IRepository<Core.PersonAggregate.Person> _repository;

  public CreatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<int>> Handle(CreatePersonCommand request,
    CancellationToken cancellationToken)
  {
    var newContributor = new Core.PersonAggregate.Person(request);
    var createdItem = await _repository.AddAsync(newContributor, cancellationToken);

    return createdItem.Id;
  }
}
