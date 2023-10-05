using Ardalis.Result;

namespace TEKO.Testing.Core.Interfaces;

public interface IDeletePersonService
{
  public Task<Result> DeletePerson(int personId);
}
