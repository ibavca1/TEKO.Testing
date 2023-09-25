using Ardalis.Specification;


namespace TEKO.Testing.Core.PersonAggregate.Specifications;

public sealed class PersonByIdSpec : Specification<Person>
{
  public PersonByIdSpec(int personId)
  {
    Query.Where(p => p.Id == personId);
  }
}
