using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SportWebSite.Domain.Authorization;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using SportWebSite.Services;
using System;
using System.Collections.Generic;

namespace SportWebSite.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly ILogger<TeamController> _logger;

        public TeamController(ITeamService teamService, ILogger<TeamController> logger)
        {
            _logger = logger;
            _teamService = teamService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("ShowTeams", "Team");
        }

        [AllowAnonymous]
        public IActionResult ShowTeams()
        {
            return View(_teamService.GetTeams());
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpGet]
        public IActionResult AddTeam()
        {
            var teams = _teamService.GetAvailablePlayers();

            return View(teams);
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpPost]
        public IActionResult AddTeam(TeamServiceModel teamViewModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input team model.");
                return View("AddTeam", teamViewModel);
            }

            _teamService.AddNewTeam(teamViewModel);

            _logger.LogInformation($"Team {teamViewModel.TeamName} has been added.");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var team = _teamService.GetServiceModelTeamById(id);
            var teamWithNullTeamPlayers = _teamService.GetAvailablePlayers();

            var playersList = new List<SelectListItem>();
            var freeAgentsList = new List<SelectListItem>();

            foreach (var player in team.Players)
            {
                playersList.Add(new SelectListItem { Text = player.Name, Value = player.Id.ToString() });
            }
            foreach (var player in teamWithNullTeamPlayers.Players)
            {
                freeAgentsList.Add(new SelectListItem { Text = player.Name, Value = player.Id.ToString() });
            }

            ViewBag.playersList = playersList;
            ViewBag.freeAgentsList = freeAgentsList;

            if (team is null)
            {
                _logger.LogError("Team is null.");
                throw new NullReferenceException(nameof(team));
            }

            _logger.LogInformation($"{playersList.Count} players are in {team.TeamName} now.");
            _logger.LogInformation($"{freeAgentsList.Count} are free agents now.");
            return View(team);
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        public IActionResult EditTeam(TeamServiceModel teamServiceModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid input team model.");
                return View("EditTeam", teamServiceModel);
            }

            _teamService.UpdatePlayersTeam(teamServiceModel);

            _logger.LogInformation($"{teamServiceModel.TeamName} has been edited.");
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpGet]
        [ActionName("DeleteTeam")]
        public IActionResult ConfirmDelete(int id)
        {
            Team team = _teamService.GetTeamById(id);
            if (team != null)
            {
                _logger.LogInformation($"{team.TeamName} has been deleted.");
                return View(team);
            }
            else
            {
                _logger.LogError("Error while deleting team.");
                return NotFound();
            }
        }

        [Authorize(Roles = Roles.ADMIN + "," + Roles.MANAGER)]
        [HttpPost]
        public IActionResult DeleteTeam(int id)
        {
            return _teamService.RemoveTeam(id) ? RedirectToAction("Index") : NotFound();
        }
    }
}
