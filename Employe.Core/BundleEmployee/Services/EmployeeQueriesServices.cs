using Employe.Core.BundleEmployee.Models;
using Employe.Core.BundleEmployee.Repositories;
using Employe.Core.BundleEmployee.Services.Impl;
using Employee.Core.BundleEmployee.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.BundleEmployee.Services
{
    public class EmployeeQueriesServices : IEmployeeQueriesService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeQueriesServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employees?>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employees> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee is null)
            {
                throw new NotFoundException($"El empleado con Id: {id} no fue encontrado.");
            }
            return employee;
        }
    }
}
