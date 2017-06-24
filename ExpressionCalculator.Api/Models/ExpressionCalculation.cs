using System;
using System.Runtime.Serialization;

namespace ExpressionCalculator.Api.Models
{
    [DataContract]
    public class ExpressionCalculation
    {                    
        public int Id { get; set; }
     
        [DataMember()]
        public string Expression { get; set; }

        [DataMember()]
        public CalculationResult CalculationResult { get; set; }

        [DataMember()]
        public DateTime DateGenerated { get; set; }
    }
}