using System.Collections.Generic;
using ExpressionCalculator.Api.Models;

namespace ExpressionCalculator.Api.Services
{
    public interface ICalculationService
    {
        CalculationResult ProcessCalculation(string expression);

        IEnumerable<ExpressionCalculation> GetHistory();
    }
}