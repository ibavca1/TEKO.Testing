using Ardalis.SharedKernel;
using FluentAssertions;
using NSubstitute;
using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.UseCases.Persons.Create;
using Xunit;

namespace TEKO.Testing.UnitTests.UseCases.Contributors;

public class CreateContributorHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly IRepository<Person> _repository = Substitute.For<IRepository<Person>>();
  private CreatePersonHandler _handler;

  public CreateContributorHandlerHandle()
  {
      _handler = new CreatePersonHandler(_repository);
  }

  private Person CreateContributor()
  {
    return new Person{Name = _testName};
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {
    _repository.AddAsync(Arg.Any<Person>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateContributor()));
    var result = await _handler.Handle(
      new CreatePersonCommand(_testName, Surname:"Belonogov", Patronymic:"V"), 
      CancellationToken.None);

    result.IsSuccess.Should().BeTrue();    
  }
}
