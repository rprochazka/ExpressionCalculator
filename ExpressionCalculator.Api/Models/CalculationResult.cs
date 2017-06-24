using System.Runtime.Serialization;

namespace ExpressionCalculator.Api.Models
{
    [DataContract]
    public class CalculationResult
    {
        [DataMember()]
        public decimal Result { get; set; }

        [DataMember()]
        public bool IsSuccessfull { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public CalculationError CalculationError { get; set; }
    }
}