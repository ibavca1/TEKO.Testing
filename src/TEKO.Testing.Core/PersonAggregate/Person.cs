using Ardalis.SharedKernel;

namespace TEKO.Testing.Core.PersonAggregate;
public class Person: EntityBase, IAggregateRoot
{
  public string? Name { get; set; }
  public string? Surname { get; set; }
  public string? Patronymic { get; set; }
  public int Age { get; set; }
  public Appointment? Appointment { get; set; }
  public int  Gender { get; set; }
  public ICollection<TimeOff>? TimeOff { get; set; }
}
