using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers;

[ApiController]
[Route("api/compensation")]
public class CompensationController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly ICompensationService _compensationService;
    private readonly IEmployeeService _employeeService;

    public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService,
        IEmployeeService employeeService)
    {
        _logger = logger;
        _compensationService = compensationService;
        _employeeService = employeeService;
    }

    [HttpPost]
    public IActionResult CreateCompensation([FromBody] Compensation compensation)
    {
        _logger.LogDebug(
            $"Received compensation create request for '{compensation.Employee.FirstName} {compensation.Employee.LastName}'");


        Employee employee = _employeeService.GetById(compensation.Employee.EmployeeId);

        compensation.Employee = employee;
        _compensationService.Create(compensation);

        return CreatedAtRoute("getCompensationById", new { id = compensation.Employee.EmployeeId }, compensation);
    }

    [HttpGet("{id}", Name = "getCompensationById")]
    public IActionResult GetCompensationById(String id)
    {
        _logger.LogDebug($"Received compensation get request for employee '{id}'");

        var compensation = _compensationService.GetById(id);

        if (compensation == null)
            return NotFound();

        return Ok(compensation);
    }
}