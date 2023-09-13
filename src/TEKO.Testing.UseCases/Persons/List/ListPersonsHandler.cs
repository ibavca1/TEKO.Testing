using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.UseCases.Contributors.List;

namespace TEKO.Testing.UseCases.Persons.List;

public class ListPersonsHandler : IQueryHandler<ListPersonsQuery, Result<IEnumerable<PersonDTO>>>
{
  private readonly IListPersonsQueryService _query;

  public ListPersonsHandler(IListPersonsQueryService query)
  {
    _query = query;
  }

  public async Task<Result<IEnumerable<PersonDTO>>> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
