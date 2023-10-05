using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using TEKO.Testing.Core.PersonAggregate;
using TEKO.Testing.Core.PersonAggregate.Events;
using Xunit;

namespace TEKO.Testing.UnitTests.Core.Services;

public class DeletePersonService_DeletePerson
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;
  private readonly ILogger<DeletePersonService> _logger;
  
  public DeletePersonService_DeletePerson(
    IRepository<Person> repository,
    IMediator mediator,
    ILogger<DeletePersonService> logger)
  {
    _repository = repository;
    _mediator = mediator;
    _logger = logger;
  }

  public async Task<Result> DeletePerson(int personId)
  {
    _logger.LogInformation($"Deleting person {personId}");
    var aggegateToDelete = await _repository.GetByIdAsync(personId);
    if (aggegateToDelete == null) return Result.NotFound();
    await _repository.DeleteAsync(aggegateToDelete);
    var domainEvent = new PersonDeleteEvent(personId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
