using TEKO.Testing.Web.ContributorEndpoints;

namespace TEKO.Testing.Web.Endpoints.ContributorEndpoints;

public class PersonListResponse
{
  public List<PersonRecord> Persons { get; set; } = new();
}
