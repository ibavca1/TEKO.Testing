using TEKO.Testing.Core.PersonAggregate;
using Xunit;

namespace TEKO.Testing.IntegrationTests.Data;

public class EfRepositoryAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddsContributorAndSetsId()
  {
    var testPersonName = "Anton";
    var testPersonSurname = "Belonogov";
    var testPatronymic = "Vasilevich";
    var repository = GetRepository();
    await repository.AddAsync(new Person
    {
      Name = testPersonName,
      Surname = testPersonSurname,
      Patronymic = testPatronymic
    });
    
    var newPerson = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(testPersonName, newPerson?.Name);
    Assert.Equal(testPersonSurname, newPerson?.Surname);
    Assert.True(newPerson?.Id > 0);
  }
}
