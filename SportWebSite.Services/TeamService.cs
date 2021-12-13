using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportWebSite.Data.Repository;
using SportWebSite.Domain.Entities;
using SportWebSite.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportWebSite.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public TeamServiceModel AddNewTeam(TeamServiceModel teamServiceModel)
        {
            var newTeam = _mapper.Map<Team>(teamServiceModel);

            _unitOfWork.Teams.Add(newTeam);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();

            return teamServiceModel;
        }

        public Team GetTeamById(int id)
        {
            return _unitOfWork.Teams.Get(id);
        }

        public IEnumerable<Team> GetTeams()
        {
            return _unitOfWork.Teams.GetAll();
        }

        public bool RemoveTeam(int id)
        {
            bool flag = _unitOfWork.Teams.Delete(id);
            if (flag)
            {
                _unitOfWork.Commit();
            }
            _unitOfWork.Dispose();

            return flag;
        }

        public Team UpdateTeam(TeamServiceModel teamServiceModel)
        {
            var players = new List<Player>();
            var excludedPlayers = new List<Player>();
            foreach (var id in teamServiceModel.PlayerIds)
            {
                players.Add(_unitOfWork.Players.GetAll().FirstOrDefault(p => p.Id == id));
                excludedPlayers.Add(_unitOfWork.Players.GetAll().FirstOrDefault(p => p.Id != id));
            }
            var team = new Team
            {
                Id = teamServiceModel.Id,
                Players = players,
                SportType = teamServiceModel.SportType,
                TeamName = teamServiceModel.TeamName
            };

            _unitOfWork.Teams.Update(team);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();

            return team;
        }

        public void UpdatePlayersTeam(TeamServiceModel teamServiceModel)
        {
            var excludedPlayers = _unitOfWork.Players.GetAll()
               .Where(w => w.TeamId == teamServiceModel.Id)
               .Where(w => !teamServiceModel.PlayerIds.Contains(w.Id))
               .ToList();

            var addedPlayers = _unitOfWork.Players.GetAll()
               .Where(w => teamServiceModel.PlayerIds.Contains(w.Id))
               .ToList();

            var players = new List<Player>();
            players.AddRange(excludedPlayers);
            players.AddRange(addedPlayers);

            excludedPlayers.ForEach(f => f.TeamId = null);
            addedPlayers.ForEach(f => f.TeamId = teamServiceModel.Id);

            _unitOfWork.UpdateRange(players);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();
        }

        public TeamServiceModel GetAvailablePlayers()
        {
            var teamServiceModel = new TeamServiceModel
            {
                Players = _unitOfWork.Players.GetAll()
                .Where(p => p.TeamId == null)
            };

            return teamServiceModel;
        }

        public TeamServiceModel GetServiceModelTeamById(int id)
        {
            var team = ((IQueryable<Team>)_unitOfWork.Teams.GetAll())
                .Include(t => t.Players)
                .FirstOrDefault(f => f.Id == id);

            var teamServiceModel = _mapper.Map<TeamServiceModel>(team);

            return teamServiceModel;
        }
    }
}