using MediatR;
using Microsoft.Extensions.Logging;
using TEKO.Testing.Core.PersonAggregate.Events;

namespace TEKO.Testing.Core.PersonAggregate.Handlers;

public class PersonDeleteHandler:INotificationHandler<PersonDeleteEvent>
{
  private readonly ILogger<PersonDeleteHandler> _logger;

  public PersonDeleteHandler(ILogger<PersonDeleteHandler> logger)
  {
    _logger = logger;
  }
  public async Task Handle(PersonDeleteEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Person Deleted event for {contributorId}", domainEvent.PersonId);
    await Task.Delay(1);
  }
}
