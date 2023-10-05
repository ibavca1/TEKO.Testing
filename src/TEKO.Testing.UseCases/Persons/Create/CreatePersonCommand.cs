using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Persons.Create;

public record CreatePersonCommand(string Name, string Surname, string Patronymic):ICommand<Result<int>>;
