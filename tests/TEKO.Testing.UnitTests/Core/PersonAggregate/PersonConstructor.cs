using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.UseCases.Persons.Create;
using Xunit;

namespace TEKO.Testing.UnitTests.Core.PersonAggregate;

public class ContributorConstructor
{
  private readonly string _testName = "test name";
  private Person? _testPerson;

  private Person CreatePerson()
  {
    return new Person { Name = _testName };
  }

  [Fact]
  public void InitializesName()
  {
    _testPerson = CreatePerson();

    Assert.Equal(_testName, _testPerson.Name);
  }
}
