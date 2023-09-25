using Ardalis.Result;
using TEKO.Testing.Core.PersonAggregate.Events;
using TEKO.Testing.Core.Interfaces;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Core.Services;

public class AddPersonService : IAddPersonService
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;
  private readonly ILogger<AddPersonService> _logger;

  public AddPersonService(IRepository<Person> repository,
    IMediator mediator,
    ILogger<AddPersonService> logger)
  {
    _repository = repository;
    _mediator = mediator;
    _logger = logger;
  }

  public async Task<Result> AddPerson(Person person)
  {
    _logger.LogInformation("Add Person {personId}", person.Id);
    var aggregateToAdd = await _repository.GetByIdAsync(person.Id);
    if (aggregateToAdd == null) return Result.NotFound();

    await _repository.AddAsync(aggregateToAdd);
    var domainEvent = new PersonAddEvent(person.Id);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
