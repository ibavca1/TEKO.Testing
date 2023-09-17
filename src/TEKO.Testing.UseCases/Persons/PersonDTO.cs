using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.UseCases.Persons;
public record PersonDTO(int Id, string Name, string Surname, string Patronymic, int Gender, int Age, Appointment appointment);
