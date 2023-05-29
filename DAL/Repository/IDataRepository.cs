using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IDataRepository
    {
        public Task<HashSet<Player>> GetPlayers();
        public Task<HashSet<Player>> GetPlayers(string? fifaCountryCode);

        public Task<List<Match>> GetMatches();
        public Task<List<Match>> GetMatches(string? fifaCountryCode);
//        public Task<List<Match>> GetMatches(string? homeTeam, string? awayTeam);
        
        public Task<List<Team>> GetTeams();
        
        public Task<List<Result>> GetTeamsResults();
        public Task<Result?> GetTeamResult(string fifaCountryCode);
        
        public Task<List<GroupedResult>> GetTeamsGroupResults();

        public Task<string> GetCountry(string fifaCode);
    }
}
