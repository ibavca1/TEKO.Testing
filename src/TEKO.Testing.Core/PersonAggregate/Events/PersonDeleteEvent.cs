using Ardalis.SharedKernel;

namespace TEKO.Testing.Core.PersonAggregate.Events;

public class PersonDeleteEvent:DomainEventBase
{
  public int PersonId { get; private set; }

  public PersonDeleteEvent(int personId)
  {
    PersonId = personId;
  }
}
