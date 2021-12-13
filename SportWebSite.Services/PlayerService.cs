using AutoMapper;
using SportWebSite.Data.Parse;
using SportWebSite.Data.Repository;
using SportWebSite.Domain.Entities;
using SportWebSite.Domain.Enums;
using SportWebSite.ServiceModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SportWebSite.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void GetPlayersFromAPI()
        {
            var parseAPI = new ParseAPI();
            var squad = parseAPI.GetDataFromAPI();
            var newPlayersList = new List<Player>();

            foreach (var player in squad.squad)
            {
                var newPlayer = new Player
                {
                    CountryOfBirth = player.countryOfBirth,
                    DateOfBirth = player.dateOfBirth,
                    Name = player.name,
                    Nationality = player.nationality,
                    Position = player.position,
                    Role = player.role
                };

                newPlayersList.Add(newPlayer);
            }

            var team = new Team
            {
                TeamName = squad.name,
                Players = newPlayersList,
                SportType = SportType.Football
            };
            AddPlayersFromAPI(team);
        }

        public PlayerServiceModel AddNewPlayer(PlayerServiceModel playerServiceModel)
        {
            var newPlayer = _mapper.Map<Player>(playerServiceModel);

            _unitOfWork.Players.Add(newPlayer);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();

            return playerServiceModel;
        }

        public Player GetPlayerById(int id)
        {
            return _unitOfWork.Players.Get(id);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _unitOfWork.Players.GetAll();
        }

        public bool RemovePlayer(int id)
        {
            bool flag = _unitOfWork.Players.Delete(id);
            if (flag)
            {
                _unitOfWork.Commit();
            }

            _unitOfWork.Dispose();

            return flag;
        }

        public Player UpdatePlayer(PlayerServiceModel playerServiceModel)
        {
            var player = _mapper.Map<Player>(playerServiceModel);

            _unitOfWork.Players.Update(player);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();

            return player;
        }

        public void AddPlayersFromAPI(Team team)
        {
            _unitOfWork.Teams.Add(team);
            _unitOfWork.Commit();

            _unitOfWork.Dispose();
        }

        public IEnumerable<PlayerServiceModel> GetPlayersFromTeam(int id)
        {
            var players = _unitOfWork.Players.GetAll()
                .Where(p => p.TeamId == id)
                .ToList();

            var serviceModelPlayers = new List<PlayerServiceModel>();

            foreach (var player in players)
            {
                var serviceModelPlayer = new PlayerServiceModel();

                serviceModelPlayer = _mapper.Map<PlayerServiceModel>(player);
                serviceModelPlayers.Add(serviceModelPlayer);
            }
            return serviceModelPlayers;
        }
    }
}