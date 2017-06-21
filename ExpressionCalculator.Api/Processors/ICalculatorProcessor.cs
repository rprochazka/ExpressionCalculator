namespace ExpressionCalculator.Api.Processors
{
    public interface ICalculatorProcessor
    {
        CalculationResult Calculate(string expression);
    }

    public class CalculationResult
    {
        public decimal Result { get; set; }
        public string Error { get; set; }
        public bool HasError { get; set; }
    }
}