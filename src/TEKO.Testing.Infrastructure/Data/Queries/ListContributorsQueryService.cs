using Microsoft.EntityFrameworkCore;
using TEKO.Testing.UseCases.Contributors;
using TEKO.Testing.UseCases.Contributors.List;
using TEKO.Testing.UseCases.Persons;
using TEKO.Testing.UseCases.Persons.List;

namespace TEKO.Testing.Infrastructure.Data.Queries;

public class ListContributorsQueryService : IListContributorsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries
  private readonly AppDbContext _db;

  public ListContributorsQueryService(AppDbContext db)
  {
    _db = db;
  }

  public async Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider
    var result = await _db.Persons.FromSqlRaw("SELECT Id, Name FROM Contributors") // don't fetch other big columns
      .Select(c => new ContributorDTO(c.Id, c.Name!))
      .ToListAsync();

    return result;
  }
}
