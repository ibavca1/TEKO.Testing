using TEKO.Testing.UseCases.Persons;

namespace TEKO.Testing.UseCases.Persons.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListPersonsQueryService
{
  Task<IEnumerable<Core.PersonAggregate.Person>> ListAsync();
}
