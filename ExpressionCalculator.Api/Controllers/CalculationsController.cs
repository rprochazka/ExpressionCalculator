using System.Collections.Generic;
using ExpressionCalculator.Api.Models;
using ExpressionCalculator.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExpressionCalculator.Api.Controllers
{
    [Route("api/v1/calculations")]
    public class CalculationsController : Controller
    {
        private readonly ICalculationService calculationService;
        public CalculationsController(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }
               
        /// <summary>
        /// get all calculations; todo - filter by page size, date range
        /// </summary>
        /// <response code="200">Status 200</response>
        [HttpGet]
        [Route("history")]
        [SwaggerOperation("CalculationHistory")]
        [SwaggerResponse(200, type: typeof(List<ExpressionCalculation>))]
        public virtual IActionResult CalculationsGet()
        {
            return Ok(calculationService.GetHistory());
        }        

        /// <summary>
        /// calculates given expression
        /// </summary>
        /// <remarks>posts a new calculation expression</remarks>
        /// <param name="expression"></param>
        /// <response code="200">Status 200</response>
        /// <response code="400">Status 400</response>
        [HttpPost]    
        [Route("")]
        [SwaggerOperation("CalculationsPost")]
        [SwaggerResponse(200, type: typeof(CalculationResult))]
        [SwaggerResponse(400, type: typeof(string))]
        public virtual IActionResult CalculationsPost([FromBody]string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return BadRequest("Expression has to be supplied");
            }
            var calculationResult = calculationService.ProcessCalculation(expression);
            return Ok(calculationResult);
        }        
    }
}