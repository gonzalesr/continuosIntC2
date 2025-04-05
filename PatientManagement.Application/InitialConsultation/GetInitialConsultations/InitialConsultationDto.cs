using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Application.InitialConsultation.GetInitialConsultations
{
    public class InitialConsultationDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string Observations { get; set; }       
    }
}
