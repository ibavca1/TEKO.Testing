using Microsoft.EntityFrameworkCore;
using TEKO.Testing.Core.PersonAggregate;
using Xunit;

namespace TEKO.Testing.IntegrationTests.Data;

public class EfRepositoryUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    var repository = GetRepository();
    var initialName = Guid.NewGuid().ToString();
    var person = new Person
    {
      Name = initialName
    };

    await repository.AddAsync(person);
    
    _dbContext.Entry(person).State = EntityState.Detached;
    
    var newPerson = (await repository.ListAsync())
        .FirstOrDefault(person => person.Name == initialName);
    if (newPerson == null)
    {
      Assert.NotNull(newPerson);
      return;
    }
    Assert.NotSame(person, newPerson);
    var newName = Guid.NewGuid().ToString();
    newPerson.UpdateName(newName);
    
    await repository.UpdateAsync(newPerson);
    
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(person => person.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(person.Name, updatedItem?.Name);
    Assert.Equal(newPerson.Id, updatedItem?.Id);
  }
}
