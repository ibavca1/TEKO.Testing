using Ardalis.Result;

namespace TEKO.Testing.UseCases.Contributors.Create;

public record CreatePersonCommand(string Name) : Ardalis.SharedKernel.ICommand<Result<int>>;
