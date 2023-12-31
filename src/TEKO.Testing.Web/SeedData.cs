﻿using TEKO.Testing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TEKO.Testing.Core.PersonAggregate;

namespace TEKO.Testing.Web;

public static class SeedData
{
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

    Random rndPerson = new Random();
    Random rndGender = new Random();
    int namesCountMale = 0;
    int surnamesCountMale = 0;
    int patronymicsCountMale = 0;
    int namesCountFamale = 0;
    int surnamesCountFamale = 0;
    int patronymicsCountFamale = 0;

    
    int appointmentsCount = 0;
    var dir = Directory.GetCurrentDirectory();
    using StreamReader personsNameMaleReader = new StreamReader($"{dir}/names_male.txt");
    using StreamReader personsNameFamaleReader = new StreamReader($"{dir}/names_famale.txt");
    using StreamReader presonsSurnameMaleReader = new StreamReader($"{dir}/surnames_male.txt");
    using StreamReader presonsSurnameFamaleReader = new StreamReader($"{dir}/surnames_famale.txt");
    using StreamReader personsPatronymicsMaleReader = new StreamReader($"{dir}/patronymics_male.txt");
    using StreamReader personsPatronymicsFamaleReader = new StreamReader($"{dir}/patronymics_famale.txt");
    using StreamReader personsAppointmentsReader = new StreamReader($"{dir}/appointments.txt");
    var namesMale = new List<string>();
    var namesFamale = new List<string>();
    var surnamesMale = new List<string>();
    var surnamesFamale = new List<string>();
    var patronymicsMale = new List<string>();
    var patronymicsFamale = new List<string>();
    var appointments = new List<string>();

    #region Names
    var nameMale = personsNameMaleReader.ReadLine();
    while(nameMale != null)
    {
      namesMale.Add(nameMale.Trim());
      namesCountMale++;
      nameMale = personsNameMaleReader.ReadLine();
    }
    var nameFamale = personsNameFamaleReader.ReadLine();
    while(nameFamale != null)
    {
      namesFamale.Add(nameFamale.Trim());
      namesCountFamale++;
      nameFamale = personsNameFamaleReader.ReadLine();
    }
    #endregion

    #region Surnames
    var surnameMale = presonsSurnameMaleReader.ReadLine();
    while(surnameMale != null)
    {
      surnamesMale.Add(surnameMale.Trim());
      surnamesCountMale++;
      surnameMale = presonsSurnameMaleReader.ReadLine();
    }
    var surnameFamale = presonsSurnameFamaleReader.ReadLine();
    while(surnameFamale != null)
    {
      surnamesFamale.Add(surnameFamale.Trim());
      surnamesCountFamale++;
      surnameFamale = presonsSurnameFamaleReader.ReadLine();
    }
    #endregion

    #region Patronymics
    var patronymicMale = personsPatronymicsMaleReader.ReadLine();
    while (patronymicMale != null)
    {
      patronymicsMale.Add(patronymicMale);
      patronymicsCountMale++;
      patronymicMale = personsPatronymicsMaleReader.ReadLine();
    }
    
    var patronymicFamale = personsPatronymicsFamaleReader.ReadLine();
    while (patronymicFamale != null)
    {
      patronymicsFamale.Add(patronymicFamale);
      patronymicsCountFamale++;
      patronymicFamale = personsPatronymicsFamaleReader.ReadLine();
    }    
    #endregion
    
    
    var appointment = personsAppointmentsReader.ReadLine();
    while (appointment != null)
    {
      appointments.Add(appointment);
      appointmentsCount++;
      appointment = personsAppointmentsReader.ReadLine();
    }

    foreach (var item in appointments)
    {
      dbContext.Add(new Appointment{Name = item});
    }
    
    List<Person> persons = new List<Person>();
    foreach(int number in Enumerable.Range(1, 100))
    {
      var gender = rndGender.Next(0, 2);
      if(gender == 0)
      {
        var a = appointments.ElementAt(rndPerson.Next(0, appointments.Count));
        persons.Add(item: new Person
        {
          Name = namesMale.ElementAt(rndPerson.Next(0, namesMale.Count)),
          Surname = surnamesMale.ElementAt(rndPerson.Next(0,surnamesMale.Count)),
          Patronymic = patronymicsMale.ElementAt(rndPerson.Next(0, patronymicsMale.Count)),
          Gender = "М",
          Age = rndPerson.Next(18, 66),
          Appointment = new Appointment
          {
            Name = appointments.ElementAt(rndPerson.Next(0, appointments.Count))
          }
        });        
      }
      else
      {
        persons.Add(item: new Person
        {
          Name = namesFamale.ElementAt(rndPerson.Next(0, namesFamale.Count)),
          Surname = surnamesFamale.ElementAt(rndPerson.Next(0,surnamesFamale.Count)),
          Patronymic = patronymicsFamale.ElementAt(rndPerson.Next(0, patronymicsFamale.Count)),
          Appointment = new Appointment
          {
            Name = appointments.ElementAt(rndPerson.Next(0, appointments.Count))
          },
          Gender = "Ж",
          Age = rndPerson.Next(18,61),
        });           
      }
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
