using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
  public async Task<IEnumerable<PersonDTO>> ListAsync()
  {
    var result = await _db.Persons.FromSqlRaw("SELECT id, name, surname, patronymic,  Gender, Age from persons")
      .Select(p=>new PersonDTO(p.Id, p.Name!, p.Surname!, p.Patronymic!,p.Gender,p.Age))
      .ToListAsync();
    return result;
  }
}
