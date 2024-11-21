using Employe.Core.BundleEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Employe.Core.BundleEmployee.Services.Impl
{
    public interface IEmployeeQueriesService
    {
        Task<IEnumerable<Employees?>> GetAllAsync();
        Task<Employees> GetByIdAsync(int id);
    }
}
