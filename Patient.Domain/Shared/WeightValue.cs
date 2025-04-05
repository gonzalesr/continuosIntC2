using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Shared
{
    public record WeightValue
    {
        public decimal Value { get; init; } // Peso en kg (puede ser decimal para mayor precisión)

        private WeightValue() { } // Constructor para EF Core

        public WeightValue(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("Weight must be greater than zero.", nameof(value));

            Value = value;
        }

        public override string ToString() => $"{Value} kg";

        public static implicit operator decimal(WeightValue weight)
        {
            return weight == null ? 0 : weight.Value;
        }

        public static implicit operator WeightValue(decimal a)
        {
            return new WeightValue(a);
        }

    }
}
