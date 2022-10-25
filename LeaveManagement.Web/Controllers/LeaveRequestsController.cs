using LeaveManagement.Common.Constants;
using LeaveManagement.Application.Contracts;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypesRepository;
        private readonly ILogger<LeaveRequestsController> _logger;

        public LeaveRequestsController(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypesRepository,
            ILogger<LeaveRequestsController> logger)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypesRepository = leaveTypesRepository;
            _logger = logger;
        }

        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var model = await _leaveRequestRepository.GetAdminLeaveRequestList();
            return View(model);
        }

        public async Task<IActionResult> MyLeaves()
        {
            var employeeId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var allocations = await _leaveAllocationRepository.GetAllVMAsync(employeeId);
            var archivalRequests = await _leaveRequestRepository.GetArchivalAsync(employeeId);
            var pendingRequests = await _leaveRequestRepository.GetPendingAsync(employeeId);

            // Technically I could've moved creating VM resposibility to one of the repositories
            // Although its arbitrary to which one 
            // Good question is whether this would speed up the process of retriving data from the DB
            // For now it stays here though
            var model = new MyLeavesVM(allocations, archivalRequests, pendingRequests);

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var model = await _leaveRequestRepository.GetLeaveRequestAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await _leaveRequestRepository.ChangeApprovalStatus(id, approved);

            }
            catch (Exception ex)
            {
                // This will actually log twice
                _logger.LogError(ex, "Error approving leave request");
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            var employeeId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (employeeId == null)
                return NotFound();

            var model = new LeaveRequestCreateVM
            {
                RequestingEmployeeId = employeeId,
                LeaveTypes = new SelectList(_leaveTypesRepository.GetEmployeeLeaveTypes(employeeId).Result, "Id", "Name")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest = await _leaveRequestRepository.CreateLeaveRequest(model);
                    if (!isValidRequest)
                    {
                        ModelState.AddModelError(string.Empty, "You do not have enough remaining allocated days");

                        model.LeaveTypes = new SelectList(_leaveTypesRepository.GetEmployeeLeaveTypes(
                            model.RequestingEmployeeId).Result, "Id", "Name", model.LeaveTypeId);
                        return View(model);
                    }
                    return RedirectToAction(nameof(MyLeaves));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating leave request");
                ModelState.AddModelError(string.Empty, "An error occurred. Please try again later or contact the admin");
            }

            model.LeaveTypes = new SelectList(_leaveTypesRepository.GetEmployeeLeaveTypes(
                model.RequestingEmployeeId).Result, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _leaveRequestRepository.CancelLeaveRequest(id);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(MyLeaves));
        }
    }
}
