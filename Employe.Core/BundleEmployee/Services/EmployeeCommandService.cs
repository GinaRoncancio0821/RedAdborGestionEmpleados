using Employe.Core.BundleEmployee.Models;
using Employe.Core.BundleEmployee.Repositories;
using Employe.Core.BundleEmployee.Services.Impl;
using Employee.Core.BundleEmployee.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employe.Core.BundleEmployee.Services
{
    public class EmployeeCommandService : IEmployeeCommandService

    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeCommandService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task Add(Employees employee)
        {
            
            await _employeeRepository.Add(employee);

        }

        public async Task Delete(Employees employee)
        {
            var employe = await _employeeRepository.GetByIdAsync(employee.EmployeeId);

            if (employe is null)
            {
                throw new NotFoundException($"El empleado con Id: {employee.EmployeeId} no fue encontrado.");
            }

            await _employeeRepository.Delete(employee);


        }

        public async Task Update(Employees employee)
        {
            var employe = await _employeeRepository.GetByIdAsync(employee.EmployeeId);

            if (employe is null)
            {
                throw new NotFoundException($"El empleado con Id: {employee.EmployeeId} no fue encontrado.");
            }

            await _employeeRepository.Update(employee);


        }
    }
}
