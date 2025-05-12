using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.Patients.GetPatients
{
     public class PatientDto
     {
          public Guid Id { get; set; }
          public string Name { get; set; }
          public DateTime BirthDate { get; set; }
          public string Gender { get; set; }
          public string Email { get; set; }
          public List<string> Phones { get; set; }
     }
}
