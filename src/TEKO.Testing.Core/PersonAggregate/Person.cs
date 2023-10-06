using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace TEKO.Testing.Core.PersonAggregate;
public class Person: EntityBase, IAggregateRoot
{
  public string? Name { get; set; }
  public string? Surname { get; set; }
  public string? Patronymic { get; set; }
  public int Age { get; set; }
  public int AppointmentId { get; set; }
  public Appointment Appointment { get; set; } = null!;
  public string?  Gender { get; set; }
  public IEnumerable<TimeOff>? TimeOff { get; set; }

  public void UpdateName(string newName)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }
}
