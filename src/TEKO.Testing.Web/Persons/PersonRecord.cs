using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Web.PersonsEndpoints;

public record PersonRecord(int Id, string Name, string Surname, string Patronymic, Appointment Appointment,  int Age, string Gender);
