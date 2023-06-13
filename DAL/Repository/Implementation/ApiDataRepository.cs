using DAL.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Specialized;

namespace DAL.Repository.Implementation
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
            cachedMatches = new List<Match>();
            cachedTeams = new List<Team>();
            cachedResults = new List<Result>();
            cachedGroupedResults = new List<GroupedResult>();
            countries = null;
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
                players.Sort();

                return players.ToHashSet();
            });
        }

        public Task<HashSet<Player>> GetPlayers(string? fifaCountryCode)
        {
            return Task.Run(async () =>
            {
                if (fifaCountryCode == null) return await GetPlayers();

                if (cachedMatches.Count == 0)
                {
                    cachedMatches.Clear();
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Query("matches").Content));
                }

                List<Player> players = new List<Player>();
                string country = await GetCountry(fifaCountryCode);

                foreach (var match in cachedMatches)
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
                }
                players.Sort();

                return players.ToHashSet();
            });
        }

        public Task<List<Match>> GetMatches()
        {
            return Task.Run(() =>
            {
                if (cachedMatches.Count == 0)
                {
                    cachedMatches.Clear();
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Query("matches").Content).ToHashSet().ToList());
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
                    cachedMatches.Clear();
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Query("matches").Content));
                }

                if (fifaCountryCode == null) return cachedMatches;

                return cachedMatches.Where(x =>
                {
                    return x.HomeTeam.Code.Equals(fifaCountryCode.ToUpper())
                            || x.AwayTeam.Code.Equals(fifaCountryCode.ToUpper());
                }).ToHashSet().ToList();
            });
        }

        public Task<List<Team>> GetTeams()
        {
            return Task.Run(() =>
            {
                if (cachedTeams.Count == 0)
                {
                    cachedTeams.Clear();
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
                    cachedResults.Clear();
                    cachedResults = JsonConvert.DeserializeObject<List<Result>>(Query("/teams/results").Content);
                }

                return cachedResults ?? new List<Result>();
            });
        }

        public Task<Result?> GetTeamResult(string fifaCountryCode)
        {
            return Task.Run(async () =>
            {
                List<Result> list = await GetTeamsResults();
                Result result = list.FirstOrDefault(x => x.FifaCode.Equals(fifaCountryCode), null);

                return result;
            });
        }

        public Task<List<GroupedResult>> GetTeamsGroupResults()
        {
            return Task.Run(() =>
            {
                if (cachedGroupedResults.Count == 0)
                {
                    cachedGroupedResults.Clear();
                    cachedGroupedResults.AddRange(JsonConvert.DeserializeObject<List<GroupedResult>>(Query("/teams/group_results").Content));
                }

                return cachedGroupedResults ?? new List<GroupedResult>();
            });
        }

        public Task<string> GetCountry(string fifaCode)
        {
            return Task.Run(async () =>
            {
                if (countries == null)
                {
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
