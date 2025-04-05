using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Shared
{
    public record HeartRateValue
    {
        public int Value { get; init; } // Ritmo cardíaco en latidos por minuto (bpm)

        private HeartRateValue() { } // Constructor para EF Core

        public HeartRateValue(int value)
        {
            if (value <= 0)
                throw new ArgumentException("La frecuencia cardíaca debe ser mayor que cero.", nameof(value));

            if (value < 40 || value > 200) // Rango típico de ritmo cardíaco
                throw new ArgumentOutOfRangeException(nameof(value), "La frecuencia cardíaca debe estar entre 40 y 200 bpm.");

            Value = value;
        }

        public override string ToString() => $"{Value} bpm";

        // Conversión implícita de int a HeartRateValue
        public static implicit operator HeartRateValue(int value) => new HeartRateValue(value);

        // Conversión implícita de HeartRateValue a int
        public static implicit operator int(HeartRateValue heartRate) => heartRate.Value;
    }
}
