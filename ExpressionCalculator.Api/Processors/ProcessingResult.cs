namespace ExpressionCalculator.Api.Processors
{
    public class ProcessingResult
    {
        public decimal Result { get; set; }
        public string Error { get; set; }
        public bool HasError { get; set; }
    }
}