using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Infrastructure.StoredModel.Entities
{
    [Table("phone")]
    public class PhoneStoredModel
    {
        [Key]
        [Column("phoneId")]
        public Guid Id { get; set; }

        [Required]
        [Column("patientId")]
        public Guid PatientId { get; set; }
        public PatientStoredModel Patient { get; set; }

        [Required]
        [StringLength(250)]
        [Column("number")]
        public string Number { get; set; }
    }
}
