using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Domain.Consultations;

namespace PatientManagement.Infrastructure.StoredModel.Entities
{
    [Table("initialConsultation")]
    public class InitialConsultationStoredModel
    {
        [Key]
        [Column("initialConsultationId")]
        public Guid Id { get; set; }

        [Column("patientId")]
        public Guid PatientId { get; set; }
        public PatientStoredModel Patient { get; set; }

        [Column("date")]
        [Required]
        public DateTime Date { get; set; }

        [Column("reason")]
        [Required]
        [StringLength(250)]
        public string Reason { get; set; }

        [Column("observations")]
        [StringLength(250)]        
        public string Observations { get; set; }

    }
}
