using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Domain.Shared
{
    public record HeightValue
    {
        public decimal Value { get; init; } // Altura en metros (puede ser decimal para mayor precisión)

        private HeightValue() { } // Constructor para EF Core

        public HeightValue(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("Height must be greater than zero.", nameof(value));

            Value = value;
        }

        public override string ToString() => $"{Value} m";

        public static implicit operator decimal(HeightValue height)
        {
            return height == null ? 0 : height.Value;
        }

        public static implicit operator HeightValue(decimal a)
        {
            return new HeightValue(a);
        }
    }
}
