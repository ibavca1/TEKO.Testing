using TEKO.Testing.Core.ContributorAggregate;
using TEKO.Testing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Web;

public static class SeedData
{
  public static readonly Contributor Contributor1 = new("Ardalis");
  public static readonly Contributor Contributor2 = new("Snowfrog");
  public static int Start { get; set; } = 1672545923;
  public static int End { get; set; } = 1704067199;
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      
      if (dbContext.Persons.Any())
      {
        return;   
      }

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {

    Random rnd = new Random();
    int namesCount = 0;
    int surnamesCount = 0;
    int patronymicsCount = 0;
    int appointmentsCount = 0;
    var dir = Directory.GetCurrentDirectory();
    using StreamReader personsNameReader = new StreamReader($"{dir}\\names.txt");
    using StreamReader presonsSurnameReader = new StreamReader($"{dir}\\surnames.txt");
    using StreamReader personsPatronymicsReader = new StreamReader($"{dir}\\patronymics.txt");
    using StreamReader personsAppointmentsReader = new StreamReader($"{dir}\\appointment.txt");
    var names = new List<string>();
    var surnames = new List<string>();
    var patronymics = new List<string>();
    var appointments = new List<string>();
    var name = personsNameReader.ReadLine();
    while(name != null)
    {
      names.Add(name.Trim());
      namesCount++;
      name = personsNameReader.ReadLine();
    }

    var surname = presonsSurnameReader.ReadLine();
    while(surname != null)
    {
      surnames.Add(surname.Trim());
      surnamesCount++;
      surname = presonsSurnameReader.ReadLine();
    }

    var patronymic = personsPatronymicsReader.ReadLine();
    while (patronymic != null)
    {
      patronymics.Add(patronymic);
      patronymicsCount++;
      patronymic = personsPatronymicsReader.ReadLine();
    }
    var appointment = personsAppointmentsReader.ReadLine();
    while (appointment != null)
    {
      appointments.Add(appointment);
      appointmentsCount++;
      appointment = personsAppointmentsReader.ReadLine();
    }
    List<Person> persons = new List<Person>();
    foreach(int number in Enumerable.Range(1, 100))
    {
      persons.Add(item: new Person
      {
        Name = names.ElementAt(rnd.Next(0, namesCount)),
        Surname = surnames.ElementAt(rnd.Next(0,surnamesCount)),
        Patronymic = patronymics.ElementAt(rnd.Next(0, patronymicsCount)),
        Appointment = new Appointment
        {
          Name = appointments.ElementAt(rnd.Next(0, appointmentsCount))
        }
      });
    }
    foreach (var item in dbContext.Persons)
    {
      dbContext.Remove(item);
    }

    foreach (var person in persons)
    {
      dbContext.Add(person);
    }
    dbContext.SaveChanges();
  }
}
