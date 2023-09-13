using Ardalis.SharedKernel;

namespace TEKO.Testing.Core.PersonAggregate.Events;

internal class PersonAddEvent : DomainEventBase
{
  public int PersonId { get; set; }

  public PersonAddEvent(int personId)
  {
    PersonId = personId;
  }
}
