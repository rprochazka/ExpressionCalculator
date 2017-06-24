using System.Collections.Generic;
using ExpressionCalculator.Api.Models;

namespace ExpressionCalculator.Api.DataLayer
{
    public class CalculationDataProvider: ICalculationDataProvider
    {
        private IDataProvider<ExpressionCalculation> dataProvider;
        public CalculationDataProvider(IDataProvider<ExpressionCalculation> dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public void Save(ExpressionCalculation expressionCalculation)
        {
            dataProvider.Save(expressionCalculation);
        }

        public IEnumerable<ExpressionCalculation> GetAll()
        {
            return dataProvider.GetAll();
        }
    }
}
