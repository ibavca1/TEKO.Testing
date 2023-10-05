using Ardalis.HttpClientTestExtensions;
using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.Web.Endpoints.PersonsEndpoints;
using TEKO.Testing.Web.PersonsEndpoints;
using Xunit;

namespace TEKO.Testing.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PersonGetById:IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public PersonGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsSeedContributorGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<PersonRecord>(GetPersonByIdRequest.BuildRoute(1));
    Assert.Equal(1, result.Id);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId101()
  {
    string route = GetPersonByIdRequest.BuildRoute(101);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}
