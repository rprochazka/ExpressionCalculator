using ExpressionCalculator.Api.Models;

namespace ExpressionCalculator.Api.Processors
{
    public interface ICalculatorProcessor
    {
        ProcessingResult Calculate(string expression);
    }
}