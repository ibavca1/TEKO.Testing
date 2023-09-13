using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TEKO.Testing.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
