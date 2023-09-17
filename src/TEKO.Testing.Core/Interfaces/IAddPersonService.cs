using Ardalis.Result;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Core.Interfaces;

public interface IAddPersonService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> AddPerson(Person person);
}
