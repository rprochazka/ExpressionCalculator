using System.Collections.Generic;

namespace ExpressionCalculator.Api.Models
{
    public class CalculationError
    {        
        public string ErrorText { get; set; }        
        
        public IEnumerable<int> Indexes { get; set; }
    }
}