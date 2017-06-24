using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ExpressionCalculator.Api.DataLayer;
using ExpressionCalculator.Api.Models;
using ExpressionCalculator.Api.Processors;

namespace ExpressionCalculator.Api.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculatorProcessor calculatorProcessor;
        private readonly ICalculationDataProvider calculationDataProvider;
        public CalculationService(ICalculatorProcessor calculatorProcessor, ICalculationDataProvider calculationDataProvider)
        {
            this.calculatorProcessor = calculatorProcessor;
            this.calculationDataProvider = calculationDataProvider;
        }

        public CalculationResult ProcessCalculation(string expression)
        {           
            //1. run the evaluation
            var processingResult = calculatorProcessor.Calculate(expression);

            //2. parse the error if failed
            IEnumerable<int> failingIndex = null;
            if (processingResult.HasError)
            {
                failingIndex = ParseErrorForForFailingIndexes(processingResult.Error);
            }
            
            //3. construct response
            var calculationResult = new CalculationResult
            {
                Result = processingResult.Result,
                IsSuccessfull = !processingResult.HasError,
                CalculationError = processingResult.HasError 
                    ? new CalculationError
                        {
                            ErrorText = processingResult.Error,
                            Indexes = failingIndex
                        }
                    : null
            };

            var expressionCalculation = new ExpressionCalculation
            {
                DateGenerated = DateTime.Now,
                Expression = expression,
                CalculationResult = calculationResult
            };

            //4. store in history
            calculationDataProvider.Save(expressionCalculation);

            return calculationResult;
        }

        public IEnumerable<ExpressionCalculation> GetHistory()
        {
            return calculationDataProvider.GetAll();
        }

        /// <summary>
        /// parse the error to try to find the faling indexes within the expression
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private IEnumerable<int> ParseErrorForForFailingIndexes(string errorMessage)
        {
            var regex = new Regex(@"line\s\d:(\d{1,})", RegexOptions.IgnoreCase);

            var errors = errorMessage.Split("\r\n".ToCharArray());
            foreach (var error in errors)
            {
                //get the last line positions mentioned in the error message
                var match = regex.Matches(error).Cast<Match>().LastOrDefault();
                if (match != null)
                {
                    var positionString = match.Groups[1].Value;

                    int position;
                    if (int.TryParse(positionString, out position))
                    {
                        yield return position;
                    }
                }
            }                          
        }
    }
}
