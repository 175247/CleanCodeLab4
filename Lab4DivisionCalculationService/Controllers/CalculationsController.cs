﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4AdditionCalculationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : Controller
    {
        [HttpGet]
        public decimal Divide([FromQuery] decimal firstNumber, [FromQuery] decimal secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}