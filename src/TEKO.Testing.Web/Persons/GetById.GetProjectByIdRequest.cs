namespace TEKO.Testing.Web.Endpoints.PersonsEndpoints;

public class GetPersonByIdRequest
{
  public const string Route = "/Persons/Detail/{PersonId:int}";
  public static string BuildRoute(int personId) => Route.Replace("{PersonId:int}", personId.ToString());

  public int PersonId { get; set; }
}
