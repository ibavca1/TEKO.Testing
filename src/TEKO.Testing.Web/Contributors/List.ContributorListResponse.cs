using TEKO.Testing.Web.ContributorEndpoints;

namespace TEKO.Testing.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}
