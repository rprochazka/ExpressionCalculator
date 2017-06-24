using System.Collections.Generic;
using ExpressionCalculator.Api.Models;

namespace ExpressionCalculator.Api.DataLayer
{
    public interface ICalculationDataProvider
    {
        void Save(ExpressionCalculation expressionCalculation);

        IEnumerable<ExpressionCalculation> GetAll();
    }
}