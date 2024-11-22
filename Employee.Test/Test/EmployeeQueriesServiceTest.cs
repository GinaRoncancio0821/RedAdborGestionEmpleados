using Employe.Core.BundleEmployee.Models;
using Employe.Core.BundleEmployee.Repositories;
using Employe.Core.BundleEmployee.Services;
using Employee.Core.BundleEmployee.Exceptions;
using Employee.Core.BundleEmployee.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace Employee.Test.Test
{
    public class EmployeeQueriesServiceTest
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly EmployeeQueriesServices _service;

        public EmployeeQueriesServiceTest()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _service = new EmployeeQueriesServices(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetEmployeeById_ExistingEmployee_ReturnsEmployeeAsync()
        {
            // Arrange
            var employee = new Employees {
                CompanyId = 1,
                CreatedOn = DateTime.Today,
                DeletedOn = DateTime.Today,
                Email = "test.test@gmail.com",
                Fax = "000.000.000",
                Name = "Rodrigo",
                Lastlogin = DateTime.Today,
                Password = "123456",
                PortalId = 1,
                RoleId = 1,
                StatusId = 1,
                Telephone = "2512057",
                UpdatedOn = DateTime.Today,
                Username = "Test"
            };
             _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(employee);

            // Act
            var result = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Rodrigo", result.Name);
        }

        [Fact]
        public async Task GetEmployeeById_NonExistingEmployee_ThrowsNotFoundException()
        {
            // Arrange
            _repositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Employees)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _service.GetByIdAsync(1));
        }
    }
}
