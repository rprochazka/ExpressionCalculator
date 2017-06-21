using System;
using System.Collections.Generic;
using ExpressionCalculator.Api.Models;
using ExpressionCalculator.Api.Processors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExpressionCalculator.Api.Controllers
{
    [Route("api/v1/calculations")]
    public class CalculationsController : Controller
    {
        private readonly ICalculatorProcessor _calculatorProcessor;
        public CalculationsController(ICalculatorProcessor calculatorProcessor)
        {
            _calculatorProcessor = calculatorProcessor;
        }
               
        /// <summary>
        /// get all calculations; todo - filter by page size, date range
        /// </summary>
        /// <response code="200">Status 200</response>
        [HttpGet]
        [Route("")]
        [SwaggerOperation("CalculationsGet")]
        [SwaggerResponse(200, type: typeof(List<ExpressionCalculation>))]
        public virtual IActionResult CalculationsGet()
        {
            return Ok(new List<ExpressionCalculation>());
        }

        /// <summary>
        /// get all calculations; todo - filter by page size, date range
        /// </summary>
        /// <response code="200">Status 200</response>
        [HttpGet]        
        [Route("{id}", Name = "GetCalculation")]
        [SwaggerOperation("CalculationGet")]
        [SwaggerResponse(200, type: typeof(ExpressionCalculation))]
        public virtual IActionResult CalculationGet(int id)
        {
            return Ok(new ExpressionCalculation());
        }


        /// <summary>
        /// post new calculation expression
        /// </summary>
        /// <remarks>posts a new calculation expression</remarks>
        /// <param name="body"></param>
        /// <response code="201">Status 201</response>
        /// <response code="400">Status 400</response>
        [HttpPost]    
        [Route("")]
        [SwaggerOperation("CalculationsPost")]
        [SwaggerResponse(201, type: typeof(ExpressionCalculation))]
        public virtual IActionResult CalculationsPost([FromBody]Expression body)
        {
            var result = _calculatorProcessor.Calculate(body.Text);
            if (!result.HasError)
            {
                return CreatedAtRoute("GetCalculation", new { id = 1 }, new ExpressionCalculation
                {
                    DateGenerated = DateTime.Now,
                    Expression = body.Text,
                    Result = result.Result,
                    Id = 1
                });
            }

            return BadRequest(result.Error);
        }
    }
}