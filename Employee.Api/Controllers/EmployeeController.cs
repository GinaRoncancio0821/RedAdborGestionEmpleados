using Employe.Core.BundleEmployee.Models;
using Employe.Core.BundleEmployee.Services;
using Employe.Core.BundleEmployee.Services.Impl;
using EmployeesManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeesManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/redarbor/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeQueriesService _employeeQueriesService;
        private readonly IEmployeeCommandService _employeeCommandService;

        public EmployeeController(IEmployeeCommandService employeeCommandService, IEmployeeQueriesService employeeQueriesService)
        {
            _employeeCommandService = employeeCommandService;
            _employeeQueriesService = employeeQueriesService;
        }

        
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Employees>>> Get()
        {
            try
            {
                return Ok(await _employeeQueriesService.GetAllAsync());
            }
            catch (DbUpdateException exeption)
            {
                ModelState.AddModelError("", "No es posible listar los empleados en este momento. Por favor intente nuevamente");
                return BadRequest(exeption);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex);
            }
        }
        
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Employees>> GetById(int id)
        {
            try
            {
                var employee = await _employeeQueriesService.GetByIdAsync(id);

                return Ok(employee);
            }
            catch (DbUpdateException exeption)
            {
                ModelState.AddModelError("", "No es posible listar el empleado. Por favor intente nuevamente");
                return BadRequest(exeption);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(DtoEmployee dtoemployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employees
                    {
                        CompanyId = dtoemployee.CompanyId,
                        CreatedOn = dtoemployee.CreatedOn,
                        DeletedOn = dtoemployee.DeletedOn,
                        Email = dtoemployee.Email,
                        Fax = dtoemployee.Fax,
                        Name = dtoemployee.Name,
                        Lastlogin = dtoemployee.Lastlogin,
                        Password = dtoemployee.Password,
                        PortalId = dtoemployee.PortalId,
                        RoleId = dtoemployee.RoleId,
                        StatusId = dtoemployee.StatusId,
                        Telephone = dtoemployee.Telephone,
                        UpdatedOn = dtoemployee.UpdatedOn,
                        Username = dtoemployee.Username

                    };

                    await _employeeCommandService.Add(employee);
                    return CreatedAtAction(nameof(Get), new { id = employee.EmployeeId }, employee);
                }
                return BadRequest();
            }
            catch (DbUpdateException exeption)
            {
                ModelState.AddModelError("", "No es posible crear el empleado. Por favor intente nuevamente. ");
                return BadRequest(exeption);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex);
            }
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(int id, DtoEmployee dtoemployee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var employee = new Employees
                    {
                        EmployeeId = id,
                        CompanyId = dtoemployee.CompanyId,
                        CreatedOn = dtoemployee.CreatedOn,
                        DeletedOn = dtoemployee.DeletedOn,
                        Email = dtoemployee.Email,
                        Fax = dtoemployee.Fax,
                        Name = dtoemployee.Name,
                        Lastlogin = dtoemployee.Lastlogin,
                        Password = dtoemployee.Password,
                        PortalId = dtoemployee.PortalId,
                        RoleId = dtoemployee.RoleId,
                        StatusId = dtoemployee.StatusId,
                        Telephone = dtoemployee.Telephone,
                        UpdatedOn = dtoemployee.UpdatedOn,
                        Username = dtoemployee.Username

                    };


                    await _employeeCommandService.Update(employee);
                    return NoContent();
                }
                return BadRequest();

            }
            catch (DbUpdateException exeption)
            {
                ModelState.AddModelError("", "No es posible guardar la información del el empleado. Por favor intente nuevamente. ");
                return BadRequest(exeption);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Employees employeeFound = await _employeeQueriesService.GetByIdAsync(id);
            if (employeeFound is null) return NotFound();
            try
            {
                await _employeeCommandService.Delete(employeeFound);
                return NoContent();
            }
            catch (DbUpdateException exeption)
            {
                ModelState.AddModelError("", "No es posible eliminar el empleado. Por favor intente nuevamente. ");
                return BadRequest(exeption);
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ex);
            }
        }



    }
}
