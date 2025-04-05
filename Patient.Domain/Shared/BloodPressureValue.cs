using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Shared
{
    public record BloodPressureValue
    {
        public int Systolic { get; init; } // Presión sistólica en mmHg
        public int Diastolic { get; init;  } // Presión diastólica en mmHg

        private BloodPressureValue() { } // Constructor para EF Core

        public BloodPressureValue(int systolic, int diastolic)
        {
            if (systolic <= 0)
                throw new ArgumentException("La presión sistólica debe ser mayor que cero.", nameof(systolic));
            if (diastolic <= 0)
                throw new ArgumentException("La presión diastólica debe ser mayor que cero.", nameof(diastolic));
            if (systolic <= diastolic)
                throw new ArgumentException("La presión sistólica debe ser mayor que la presión diastólica.");

            Systolic = systolic;
            Diastolic = diastolic;
        }

        public override string ToString() => $"{Systolic}/{Diastolic} mmHg";

        public static implicit operator (int Systolic, int Diastolic)(BloodPressureValue bloodPressure)
        {
            return bloodPressure == null ? (0, 0) : (bloodPressure.Systolic, bloodPressure.Diastolic);
        }

        public static implicit operator BloodPressureValue((int Systolic, int Diastolic) values)
        {
            return new BloodPressureValue(values.Systolic, values.Diastolic);
        }       

    }
}
