﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4MultiplicationCalculationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : Controller
    {
        [HttpGet]
        public decimal Multiply([FromQuery] decimal firstNumber, [FromQuery] decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }
    }
}
