using System;
using NCalc;


namespace ExpressionCalculator.Api.Processors
{
    public class CalculatorProcessor : ICalculatorProcessor
    {
        public CalculationResult Calculate(string expression)
        {
            try
            {
                Expression expr = new Expression(expression);
                var result = expr.Evaluate();
                if (!expr.HasErrors())
                {
                    return new CalculationResult
                    {
                        Result = Convert.ToDecimal(result)
                    };
                }
                throw new Exception(expr.Error);
            }   
            catch (Exception e)
            {
                return new CalculationResult
                {
                    HasError = true,
                    Error = e.Message
                };                
            }                        

        }
    }
}
