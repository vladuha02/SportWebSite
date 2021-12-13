using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportWebSite.Domain.Authorization;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using SportWebSite.Services;
using System;

namespace SportWebSite.Controllers
{
    [Authorize(Roles = Roles.ADMIN)]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ShowUsers", "User");
        }

        public IActionResult ShowUsers()
        {
            return View(_userService.GetAvailableUsers());
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserServiceModel userServiceModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid input user model.");
                return View("AddUser", userServiceModel);
            }

            _userService.AddNewUser(userServiceModel);

            _logger.LogInformation($"{userServiceModel.Name} has been added.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var user = _userService.GetUserById(id);

            var userViewModel = new UserServiceModel(user);

            if (user is null)
            {
                _logger.LogError("User is null.");
                throw new NullReferenceException(nameof(user));
            }

            return View(userViewModel);
        }

        [HttpPost]
        public IActionResult EditUser(UserServiceModel userServiceModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input user model.");
                return View("EditUser", userServiceModel);
            }

            _userService.UpdateUser(userServiceModel);

            _logger.LogInformation($"{userServiceModel.Name} has been edited.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("DeleteUser")]
        public IActionResult ConfirmDelete(string id)
        {
            if (id != null)
            {
                User user = _userService.GetUserById(id);
                if (user != null)
                {
                    _logger.LogInformation($"{user.Name} has been deleted.");
                    return View(user);
                }
            }
            _logger.LogError("Error while deleting user.");
            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteUser(string id)
        {
            return _userService.RemoveUser(id) ? RedirectToAction("Index") : NotFound();
        }
    }
}