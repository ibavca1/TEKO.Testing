using Ardalis.HttpClientTestExtensions;
using TEKO.Testing.Web.Persons;
using Xunit;

namespace TEKO.Testing.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class PersonList:IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public PersonList(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task Returns100Persons()
  {
    var result = await _client.GetAndDeserializeAsync<PersonListResponse>("/Persons");
    Assert.Equal(100,result.Persons.Count);
  }
}
