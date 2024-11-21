using Employe.Core.BundleEmployee.Models;
using Employe.Core.BundleEmployee.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Commands.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        private readonly IDbConnection _dbConnection;
        public EmployeeRepository(EmployeeDbContext context, IDbConnection dbConnection)
        {
            _context = context;
            _dbConnection = dbConnection;
        }

        //Methods EF
        public async Task Add(Employees employee)
        {
            _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Employees employee)
        {
            var EmployeeFound =  _context.Employees.First(c => c.EmployeeId == employee.EmployeeId);
            _context.Employees.Remove(EmployeeFound);
            await _context.SaveChangesAsync();

        }

        public async Task Update(Employees employee)
        {
              _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

        }

        //Methods Dapper
        public async Task<IEnumerable<Employees?>> GetAllAsync()
        {
            string query = "SELECT * FROM Employees";
            return await _dbConnection.QueryAsync<Employees>(query);
        }

        public async Task<Employees?> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Employees>(query, new { Id = id });
        }

    }
}
