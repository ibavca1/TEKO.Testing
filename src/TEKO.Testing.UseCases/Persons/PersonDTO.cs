using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.UseCases.Persons;
public record PersonDto(int Id, string Name, string Surname, string Patronymic, string Gender, int Age, Appointment appointment,
  IEnumerable<TimeOff> TimeOff);
