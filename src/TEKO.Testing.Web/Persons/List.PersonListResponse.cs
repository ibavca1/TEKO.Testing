﻿using TEKO.Testing.Web.ContributorEndpoints;
using TEKO.Testing.Web.PersonsEndpoints;

namespace TEKO.Testing.Web.Persons;

public class PersonListResponse
{
  public List<PersonRecord> Persons { get; init; } = new();
}
