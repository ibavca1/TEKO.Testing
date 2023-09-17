using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKO.Testing.Core.PersonAggregate;
public class TimeOff
{
  public int Id { get; set; }
  public int PersonId { get; set; }
  public Person? Person { get; set; }
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
}
