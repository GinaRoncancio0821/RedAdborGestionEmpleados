﻿using Employe.Core.BundleEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Employe.Core.BundleEmployee.Services.Impl
{
    public interface IEmployeeCommandService
    {
        Task Add(Employees employee);
        Task Update(Employees employee);
        Task Delete(Employees employee);
    }
}
