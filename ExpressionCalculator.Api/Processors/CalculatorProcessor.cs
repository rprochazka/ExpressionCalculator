using System;
using ExpressionCalculator.Api.Models;
using Expression = NCalc.Expression;


namespace ExpressionCalculator.Api.Processors
{
    public class CalculatorProcessor : ICalculatorProcessor
    {
        public ProcessingResult Calculate(string expression)
        {
            try
            {
                Expression expr = new Expression(expression);
                var result = expr.Evaluate();
                if (!expr.HasErrors())
                {
                    return new ProcessingResult
                    {
                        Result = Convert.ToDecimal(result)
                    };
                }
                throw new Exception(expr.Error);
            }   
            catch (Exception e)
            {
                return new ProcessingResult
                {
                    HasError = true,
                    Error = e.Message
                };                
            }                        

        }
    }
}
