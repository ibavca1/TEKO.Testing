using Microsoft.EntityFrameworkCore;
using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.UseCases.Persons;
using TEKO.Testing.UseCases.Persons.List;

namespace TEKO.Testing.Infrastructure.Data.Queries;
public class ListPersonsQueryService : IListPersonsQueryService
{
  private readonly AppDbContext _db;
  public ListPersonsQueryService(AppDbContext db)
  {
    _db = db;
  }
  public async Task<IEnumerable<Person>> ListAsync()
  {
    var result = await _db.Persons.ToListAsync();
    return result.Select(x=>x);
  }
}
