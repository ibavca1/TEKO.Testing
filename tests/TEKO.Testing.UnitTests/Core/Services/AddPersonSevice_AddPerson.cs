using Ardalis.SharedKernel;
using TEKO.Testing.Core.ContributorAggregate;
using TEKO.Testing.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using TEKO.Testing.Core.PeopleAggregate;
using Xunit;

namespace TEKO.Testing.UnitTests.Core.Services;

public class AddPersonService_AddPerson
{
  private readonly IRepository<Person> _repository = Substitute.For<IRepository<Person>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<AddPersonService> _logger = Substitute.For<ILogger<AddPersonService>>();

  private readonly AddPersonService _service;

  public AddPersonService_AddPerson()
  {
    _service = new AddPersonService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.AddPerson(new Person());

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}
