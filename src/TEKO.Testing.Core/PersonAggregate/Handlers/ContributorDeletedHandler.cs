using TEKO.Testing.Core.PersonAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TEKO.Testing.Core.PersonAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class PersonAddHandler : INotificationHandler<PersonAddEvent>
{
  private readonly ILogger<PersonAddHandler> _logger;

  public PersonAddHandler(ILogger<PersonAddHandler> logger)
  {
    _logger = logger;
  }

  public async Task Handle(PersonAddEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.PersonId);

    await Task.Delay(1);
  }
}
