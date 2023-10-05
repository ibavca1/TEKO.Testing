using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;
using TEKO.Testing.Core.Interfaces;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Core.Services;

public class DeletePersonService:IDeletePersonService
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;
  private readonly ILogger<DeletePersonService> _logger;

  public DeletePersonService(
    IRepository<Person> repository,
    IMediator mediator,
    ILogger<DeletePersonService> logger)
  {
    _repository = repository;
    _mediator = mediator;
    _logger = logger;
  }
  public Task<Result> DeletePerson(int personId)
  {
    throw new NotImplementedException();
  }
}
