using TEKO.Testing.Web.ContributorEndpoints;

namespace TEKO.Testing.Web.Persons;

public class PersonListResponse
{
  public List<PersonRecord> Persons { get; set; } = new();
}
