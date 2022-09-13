using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly UserManager<Employee> userManager;
        private readonly IMapper mapper;

        public EmployeesController(ILeaveAllocationRepository leaveAllocationRepository, UserManager<Employee> userManager, IMapper mapper)
        {
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var model = mapper.Map<List<EmployeeVM>>(employees);
            return View(model);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/EditAllocation/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model = await leaveAllocationRepository.GetEmployeeAllocation(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditVM model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (await leaveAllocationRepository.UpdateEmployeeAllocation(model))
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An Error has occurred. Please try again later");
            }

            model.Employee = mapper.Map<EmployeeVM>(await userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = mapper.Map<LeaveTypeVM>(await leaveAllocationRepository.GetAsync(model.Id));

            return View(model);
        }
    }
}
