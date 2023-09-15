using Ardalis.Result;

namespace TEKO.Testing.UseCases.Person.Add;

public record AddPersonCommand(string Name) : Ardalis.SharedKernel.ICommand<Result<int>>;
