﻿using Ardalis.SharedKernel;

namespace TEKO.Testing.Core.PersonAggregate;
public class Person: EntityBase, IAggregateRoot
{
  public string? Name { get; set; }
  public string? Surname { get; set; }
  public string? Patronymic { get; set; }
  public int Age { get; set; }
  public Appointment? Appointment { get; set; }
  public string?  Gender { get; set; }
  public IEnumerable<TimeOff>? TimeOff { get; set; }
}
