using System;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Services;

public class CompensationService : ICompensationService
{
    private readonly ICompensationRepository _compensationRepository;
    private readonly ILogger<EmployeeService> _logger;

    public CompensationService(ILogger<EmployeeService> logger, ICompensationRepository compensationRepository)
    {
        _compensationRepository = compensationRepository;
        _logger = logger;
    }

    public Compensation Create(Compensation compensation)
    {
        if (compensation != null)
        {
            _compensationRepository.Add(compensation);
            _compensationRepository.SaveAsync().Wait();
        }

        return compensation;
    }

    public Compensation GetById(string id)
    {
        Compensation compensation = null;
        if (!String.IsNullOrEmpty(id))
        {
            compensation = _compensationRepository.GetById(id);
        }

        return compensation;
    }
}