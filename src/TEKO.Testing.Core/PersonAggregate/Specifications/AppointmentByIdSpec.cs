using Ardalis.Specification;

namespace TEKO.Testing.Core.PersonAggregate.Specifications;

public class AppointmentByIdSpec:Specification<Appointment>
{
  public AppointmentByIdSpec(int appointmentId)
  {
    Query.Where(a => a.Id == appointmentId);
  }
}
