using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKO.Testing.UseCases.Persons;
public record PersonDTO(int Id, string Name, string Surname, string Patronymic, int Gender, int Age);
