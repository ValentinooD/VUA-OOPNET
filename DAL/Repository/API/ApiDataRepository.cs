using DAL.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Specialized;

namespace DAL.Repository.API
{
    internal class ApiDataRepository : IDataRepository
    {
        private static string URL = "http://worldcup-vua.nullbit.hr";
        private EnumGender gender;
        private List<Match> cachedMatches;
        private List<Team> cachedTeams;
        private List<Result> cachedResults;
        private List<GroupedResult> cachedGroupedResults;
        private Dictionary<string, string>? countries;

        public ApiDataRepository(EnumGender gender)
        {
            this.gender = gender;
            this.cachedMatches = new List<Match>();
            this.cachedTeams = new List<Team>();
            this.cachedResults = new List<Result>();
            this.cachedGroupedResults = new List<GroupedResult>();
            this.countries = null;
        }

        public Task<HashSet<Player>> GetPlayers()
        {
            return Task.Run(async () =>
            {
                List<Player> players = new List<Player>();

                foreach (Match match in await GetMatches())
                {
                    players.AddRange(match.HomeTeamStatistics.StartingEleven);
                    players.AddRange(match.HomeTeamStatistics.Substitutes);
                    players.AddRange(match.AwayTeamStatistics.StartingEleven);
                    players.AddRange(match.AwayTeamStatistics.Substitutes);
                }

                return players.ToHashSet();
            });
        }

        public Task<HashSet<Player>> GetPlayers(string? fifaCountryCode)
        {
            return Task.Run(async () =>
            {
                if (fifaCountryCode == null) return await GetPlayers();

                List<Player> players = new List<Player>();
                string country = await GetCountry(fifaCountryCode);
                List<Match> matches = await GetMatches();

                Parallel.ForEach(matches, match =>
                {
                    if (match.HomeTeamStatistics.Country.Equals(country))
                    {
                        players.AddRange(match.HomeTeamStatistics.StartingEleven);
                        players.AddRange(match.HomeTeamStatistics.Substitutes);
                    }

                    if (match.AwayTeamStatistics.Country.Equals(country))
                    {
                        players.AddRange(match.AwayTeamStatistics.StartingEleven);
                        players.AddRange(match.AwayTeamStatistics.Substitutes);
                    }
                });

                return players.ToHashSet();
            });
        }

        public Task<List<Match>> GetMatches()
        {
            return Task.Run(() =>
            {
                if (cachedMatches.Count == 0)
                {
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Query("matches").Content));
                }

                return cachedMatches ?? new List<Match>();
            });
        }

        public Task<List<Match>> GetMatches(string? fifaCountryCode)
        {
            return Task.Run(() =>
            {
                if (cachedMatches.Count == 0)
                {
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Query("matches").Content));
                }

                return cachedMatches.Where(x => x.WinnerCode.Equals(fifaCountryCode.ToUpper())).ToList(); ;
            });
        }

        public Task<List<Team>> GetTeams()
        {
            return Task.Run(() =>
            {
                if (cachedTeams.Count == 0)
                {
                    cachedTeams.AddRange(JsonConvert.DeserializeObject<List<Team>>(Query("teams").Content));
                }

                return cachedTeams ?? new List<Team>();
            });
        }

        public Task<List<Result>> GetTeamsResults()
        {
            return Task.Run(() =>
            {
                if (cachedResults == null || cachedResults.Count == 0)
                {
                    cachedResults = JsonConvert.DeserializeObject<List<Result>>(Query("/teams/results").Content);
                }

                return cachedResults ?? new List<Result>();
            });
        }

        public Task<List<GroupedResult>> GetTeamsGroupResults()
        {
            return Task.Run(() =>
            {
                if (cachedGroupedResults.Count == 0)
                {
                    cachedGroupedResults.AddRange(JsonConvert.DeserializeObject<List<GroupedResult>>(Query("/teams/group_results").Content));
                }

                return cachedGroupedResults ?? new List<GroupedResult>();
            });
        }

        public Task<string> GetCountry(string fifaCode)
        {
            return Task.Run(async () =>
            {
                if (countries == null) {
                    countries = new Dictionary<string, string>();

                    List<Team> teams = await GetTeams();
                    foreach (Team team in teams)
                    {
                        countries.Add(team.FifaCode, team.Country);
                    }
                }

                return countries.GetValueOrDefault(fifaCode) ?? string.Empty;
            });
        }

        // UTILS

        private RestResponse Query(string endpoint)
        {
            var client = new RestClient(URL);
            var request = new RestRequest("/" + gender.ToString().ToLower() + "/" + endpoint);
            var response = client.ExecuteGet(request);
            return response;
        }
    }
}
