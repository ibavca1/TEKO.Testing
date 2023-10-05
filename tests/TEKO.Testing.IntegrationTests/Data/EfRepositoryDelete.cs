using TEKO.Testing.Core.PersonAggregate;
using Xunit;

namespace TEKO.Testing.IntegrationTests.Data;

public class EfRepositoryDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var person = new Person
    {
      Name = initialName
    };
    await repository.AddAsync(person);

    // delete the item
    await repository.DeleteAsync(person);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        person => person.Name == initialName);
  }
}
