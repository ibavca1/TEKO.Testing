using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Contributors.Update;

public class UpdatePersonHandler : ICommandHandler<UpdatePersonCommand, Result<ContributorDTO>>
{
  private readonly IRepository<Core.PersonAggregate.Person> _repository;

  public UpdatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<ContributorDTO>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    var existingContributor = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
    if (existingContributor == null)
    {
      return Result.NotFound();
    }

    existingContributor.UpdateName(request.NewName!);

    await _repository.UpdateAsync(existingContributor, cancellationToken);

    return Result.Success(new ContributorDTO(existingContributor.Id, existingContributor.Name));
  }
}
