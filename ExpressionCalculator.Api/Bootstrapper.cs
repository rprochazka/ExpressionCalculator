using ExpressionCalculator.Api.DataLayer;
using ExpressionCalculator.Api.Processors;
using ExpressionCalculator.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressionCalculator.Api
{
    public static class Bootstrapper
    {
        public static void Init(IServiceCollection services)
        {
            services.AddSingleton<ICalculatorProcessor, CalculatorProcessor>();
            
            services.AddSingleton(typeof(IDataProvider<>), typeof(MemoryStoreDataProvider<>));

            services.AddSingleton<ICalculationDataProvider, CalculationDataProvider>();

            services.AddSingleton<ICalculationService, CalculationService>();
        }
    }
}
