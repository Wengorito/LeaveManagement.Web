using AutoMapper;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Constants;
using LeaveManagement.Common.Models;
using LeaveManagement.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = Roles.Administrator)]
    public class EmployeesController : Controller
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILeaveAllocationRepository leaveAllocationRepository, UserManager<Employee> userManager, IMapper mapper, ILogger<EmployeesController> logger)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: EmployeesController
        public async Task<IActionResult> Index()
        {
            var employees = await _userManager.GetUsersInRoleAsync(Roles.User);
            var model = _mapper.Map<List<EmployeeVM>>(employees);
            return View(model);
        }

        // GET: EmployeesController/ViewAllocations/employeeId
        public async Task<IActionResult> ViewAllocations(string id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/EditAllocation/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
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
                if (ModelState.IsValid)
                {
                    if (await _leaveAllocationRepository.UpdateEmployeeAllocation(model))
                        return RedirectToAction(nameof(ViewAllocations), new { id = model.EmployeeId });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating editing allocation");
                ModelState.AddModelError(string.Empty, "An Error has occurred. Please try again later");
            }

            model.Employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(model.EmployeeId));
            model.LeaveType = _mapper.Map<LeaveTypeVM>(await _leaveAllocationRepository.GetAsync(model.Id));

            return View(model);
        }
    }
}