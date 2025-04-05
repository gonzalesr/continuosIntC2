using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagement.Domain.Patients;

namespace PatientManagement.Infrastructure.StoredModel.Entities
{
    [Table("patient")]
    public class PatientStoredModel
    {
        [Key]
        [Column("patientId")]
        public Guid Id { get; set; }

        [Column("name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("birthDate")]
        [Required]
        public DateTime BirthDate { get; set; }

        [Column("gender")]
        [Required]
        [StringLength(250)]
        public string Gender { get; set; }

        [Column("email")]
        [StringLength(250)]
        [Required]
        public string Email { get; set; }

        public List<PhoneStoredModel> Phone { get; set; }
        public List<InitialConsultationStoredModel> Consultations { get; set; }
    }
}
