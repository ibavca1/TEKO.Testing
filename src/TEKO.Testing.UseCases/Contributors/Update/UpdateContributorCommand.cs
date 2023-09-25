using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Contributors.Update;

public record UpdatePersonCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
