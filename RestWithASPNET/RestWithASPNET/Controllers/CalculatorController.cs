using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CalculatorController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController (ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                var response = "soma: " + sum.ToString();

                return Ok(response);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                var response = "subtração: " + sub.ToString();

                return Ok(response);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                var response = "multiplicação: " + mult.ToString();

                return Ok(response);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("spl/{firstNumber}/{secondNumber}")]
        public IActionResult Split(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var spl = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                var response = "Divisão: " + spl.ToString();

                return Ok(response);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Medium(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var med = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                var response = "média: " + med.ToString();

                return Ok(response);
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sqr/{firstNumber}")]
        public IActionResult Square(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var sqr1 = SquareIt(ConvertToDouble(firstNumber));
                var response = "Raíz quadrada de " + firstNumber + " é: " + sqr1.ToString();

                return Ok(response);
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
                return decimalValue;
            return 0;
        }

        private double ConvertToDouble(string firstNumber)
        {
            double doubleValue;
            if(double.TryParse(firstNumber, out doubleValue))
                return doubleValue;
            return 0;
        }
        private double SquareIt(double number)
        {
            double response;
            response = Math.Sqrt(number);
            return response;
        }
    }
}
