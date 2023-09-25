using Ardalis.Result;
using Ardalis.SharedKernel;
using TEKO.Testing.UseCases.Persons;

namespace TEKO.Testing.UseCases.Persons.List;

public record ListPersonsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<PersonDTO>>>;
