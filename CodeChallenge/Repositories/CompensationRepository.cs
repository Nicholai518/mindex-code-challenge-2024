using System;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Data;

namespace CodeChallenge.Repositories;

public class CompensationRepository : ICompensationRepository
{
    private readonly CompensationContext _compensationContext;
    private readonly ILogger<ICompensationRepository> _logger;

    public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
    {
        _compensationContext = compensationContext;
        _logger = logger;
    }

    public Compensation Add(Compensation compensation)
    {
        _logger.LogDebug("Adding compensation for Employee id: " + compensation.Employee.EmployeeId);
        compensation.CompensationId = Guid.NewGuid().ToString();
        _compensationContext.Compensations.Add(compensation);
        return compensation;
    }

    public Compensation GetById(string id)
    {
        _logger.LogDebug("Getting compensation with id: " + id);
        return _compensationContext.Compensations.SingleOrDefault(c => c.Employee.EmployeeId == id);
    }

    public Task SaveAsync()
    {
        return _compensationContext.SaveChangesAsync();
    }
}