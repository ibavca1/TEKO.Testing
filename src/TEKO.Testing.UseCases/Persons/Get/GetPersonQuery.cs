using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Persons.Get;

public record GetPersonQuery(int PersonId) : IQuery<Result<PersonDto>>;
