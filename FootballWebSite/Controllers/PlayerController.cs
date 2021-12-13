using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportWebSite.Domain.Authorization;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using SportWebSite.Services;

namespace SportWebSite.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(IPlayerService playerService, ILogger<PlayerController> logger)
        {
            _logger = logger;
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("ShowPlayers", "Player");
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpGet]
        public IActionResult AddPlayer()
        {
            return View();
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpPost]
        public IActionResult AddPlayer(PlayerServiceModel playerViewModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input player model.");
                return View("AddPlayer", playerViewModel);
            }

            _playerService.AddNewPlayer(playerViewModel);

            _logger.LogInformation($"Player {playerViewModel.name} has been added.");
            return RedirectToAction("ShowMessage", "Player");
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpGet]
        public IActionResult EditPlayer(int id)
        {
            var player = _playerService.GetPlayerById(id);

            var playerServiceModel = new PlayerServiceModel
            {
                countryOfBirth = player.CountryOfBirth,
                dateOfBirth = player.DateOfBirth,
                name = player.Name,
                nationality = player.Nationality,
                position = player.Position,
                role = player.Role
            };

            return View(playerServiceModel);
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpPost]
        public IActionResult EditPlayer(PlayerServiceModel playerServiceModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input player model.");
                return View("EditPlayer", playerServiceModel);
            }

            _playerService.UpdatePlayer(playerServiceModel);

            _logger.LogInformation($"Player {playerServiceModel.name} has been edited.");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpGet]
        [ActionName("DeleteTeam")]
        public IActionResult ConfirmDelete(int id)
        {
            Player player = _playerService.GetPlayerById(id);
            if (player != null)
            {
                _logger.LogInformation($"Player {player.Name} has been deleted.");
                return View(player);
            }
            else
            {
                _logger.LogError("Error while deleting player.");
                return NotFound();
            }
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpPost]
        public IActionResult DeletePlayer(int id)
        {
            return _playerService.RemovePlayer(id) ? RedirectToAction("ShowTeams", "Team") : NotFound();
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER + "," + Roles.SCOUT)]
        [HttpGet]
        public IActionResult ShowPlayers(int id)
        {
            return View(_playerService.GetPlayersFromTeam(id));
        }

        public IActionResult ShowMessage(bool isApi)
        {
            if (isApi)
            {
                _logger.LogInformation("API's players have been successfully synced.");
                _playerService.GetPlayersFromAPI();
            }

            return View();
        }
    }
}