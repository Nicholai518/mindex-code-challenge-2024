using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reportingStructure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id}", Name = "getReportingStructureForEmployee")]
        public IActionResult GetReportingStructureForEmployee(String id)
        {
            _logger.LogDebug($"Received employee id : '{id}' , now getting reporting structure");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            ReportingStructure reportingStructure = new ReportingStructure(employee);

            return Ok(reportingStructure);
        }
    }
}