using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Exceptions;
using Source.Models;
using Source.Utilities;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {
        private List<Team> _teams;
        private List<Player> _players;

        public SoccerTeamsManager()
        {
            _teams = new List<Team>();
            _players = new List<Player>();
        }

        private void SearchTeam(long id)
        {
            if(!_teams.Any(x => x.Id == id))
            {
                throw new TeamNotFoundException();
            }
        }

        private Player SearchPlayer(long id)
        {
            if(!_players.Any(x => x.Id == id))
            {
                throw new PlayerNotFoundException();
            }

            return _players.Where(x => x.Id == id).First();        
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            if(_players.Any(x => x.Id == id))
            {
                throw new UniqueIdentifierException();
            }

            SearchTeam(teamId);

            var player = new Player(id, teamId, name, birthDate, skillLevel, salary);

            _players.Add(player);
        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            if(_teams.Any(x => x.Id == id))
            {
                throw new UniqueIdentifierException();
            }

            var team = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);

            _teams.Add(team);
        }

        public long GetBestTeamPlayer(long teamId)
        {
           SearchTeam(teamId);

           return _players.Where(x => x.TeamId == teamId).OrderByDescending(x => x.SkillLevel).ToList().First().Id;

        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            SearchTeam(teamId);

            return _players.Where(x => x.TeamId == teamId).OrderByDescending(x => x.Salary).ToList().First().Id;           
        }

        public long GetOlderTeamPlayer(long teamId)
        {

            SearchTeam(teamId);

            return _players.Where(x => x.TeamId == teamId).OrderBy(x => x.BirthDate).ThenBy(X => X.Id).First().Id;
        }

        public string GetPlayerName(long playerId)
        {
            SearchPlayer(playerId);

            return _players.Where(x => x.Id == playerId).Select(x => x.Name).ToString();
        }

        public decimal GetPlayerSalary(long playerId)
        {
            SearchPlayer(playerId);

            return _players.Where(x => x.Id == playerId).Select(x => x.Salary).First();
        }

        public long GetTeamCaptain(long teamId)
        {
            SearchTeam(teamId);
            var getTeamCaptain = _teams.Where(x => x.Id == teamId).First();

            if (getTeamCaptain.Captain == null)
            {
                throw new CaptainNotFoundException("Captain not found");
            }

            return getTeamCaptain.Captain.Id;
        }

        public string GetTeamName(long teamId)
        {
            SearchTeam(teamId);

            return _teams.Where(x => x.Id == teamId).Select(x => x.Name).First();
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            SearchTeam(teamId);

            return _players.Where(x => x.TeamId == teamId).OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public List<long> GetTeams()
        {
            return _teams.OrderBy(x => x.Id).Select(x => x.Id).ToList();
        }

        public List<long> GetTopPlayers(int top)
        {
            return _players.OrderByDescending(x => x.SkillLevel).Select(x => x.Id).Take(top).ToList();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            SearchTeam(teamId);
            SearchTeam(visitorTeamId);
            var visitorShirtColor = _teams.Where(x => x.Id == visitorTeamId).Select(x => x.MainShirtColor).First();
            var teamShirtColor = _teams.Where(x => x.Id == teamId).Select(x => x.MainShirtColor).First();

            if (visitorShirtColor == teamShirtColor)
            {
                return _teams.Where(x => x.Id == visitorTeamId).Select(x => x.SecondaryShirtColor).First();
            }

            return visitorShirtColor;
        }

        public void SetCaptain(long playerId)
        {
            SearchPlayer(playerId);
            var playerSetCaptain = _players.Where(x => x.Id == playerId).First();
            var team = _teams.Where(x => x.Id == playerSetCaptain.TeamId).First();

            team.SetCaptain(playerSetCaptain);
        }

    }
}
