using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SharedKernel;

namespace TEKO.Testing.Core.PeopleAggregate;
public class Person: EntityBase, IAggregateRoot
{
  public string? Name { get; set; }
  public string? Surname { get; set; }
  public string? Patronymic { get; set; }
  public int Age { get; set; }
  public int AppointmentId { get; set; }
  public int  Gender { get; set; }
  public ICollection<TimeOff>? TimeOff { get; set; }
  public Person()
  {
    
  }
}
