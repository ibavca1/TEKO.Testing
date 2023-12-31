﻿using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.UseCases.Persons.List;

public class ListPersonsHandler : IQueryHandler<ListPersonsQuery, Result<IEnumerable<PersonDto>>>
{
  private readonly IListPersonsQueryService _query;

  public ListPersonsHandler(IListPersonsQueryService query)
  {
    _query = query;
  }

  public async Task<Result<IEnumerable<PersonDto>>> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    /*var persons = result.Select<PersonDto>(p => new PersonDto(
        p.Id,
        p.Name,
        p.Surname,
        p.Patronymic,
        p.Gender!,
        p.Age,
        p.Appointment!)),
        p.TimeOff??new List<TimeOff>()
      );*/
    return Result.Success(result);
  }
}
