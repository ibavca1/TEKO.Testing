using Ardalis.Specification;
using TEKO.Testing.Core.PeopleAggregate;

namespace TEKO.Testing.Core.PersonAggregate.Specifications;

public class PersonByIdSpec : Specification<Person>
{
  public PersonByIdSpec(int personId)
  {
    Query
        .Where(p => p.Id == personId);
  }
}
