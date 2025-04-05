using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Infrastructure.StoredModel.Entities
{
    [Table("periodicEvaluation")]
    public class PeriodicEvaluationStoredModel
    {
        [Key]
        [Column("periodicEvaluationId")]
        public Guid Id { get; set; }

        [Column("patientId")]
        public Guid PatientId { get; set; }
        public PatientStoredModel Patient { get; set; }

        [Column("date")]
        [Required]
        public DateTime Date { get; set; }

        [Column("evaluationNotes")]
        [Required]
        [StringLength(2000)]
        public string EvaluationNotes { get; set; }

        [Column("weight", TypeName = "decimal(18,2)")]        
        public decimal Weight { get; set; }
        [Column("height", TypeName = "decimal(18,2)")]
        public decimal Height { get; set; }
        [Column("systolic")]
        public int Systolic { get; set; }
        [Column("diastolic")]
        public int Diastolic { get; set; }
        [Column("heartRate")]
        public int HeartRate { get; set; }

    }
}
