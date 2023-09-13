using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.UseCases.Persons;
using TEKO.Testing.UseCases.Persons.List;

namespace TEKO.Testing.UseCases.Contributors.List;

public class ListContributorsHandler : IQueryHandler<ListContributorsQuery, Result<IEnumerable<ContributorDTO>>>
{
  private readonly IListContributorsQueryService _query;

  public ListContributorsHandler(IListContributorsQueryService query)
  {
    _query = query;
  }

  public async Task<Result<IEnumerable<ContributorDTO>>> Handle(ListContributorsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
