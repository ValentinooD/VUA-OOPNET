using DAL.Models;
using Newtonsoft.Json;

namespace DAL.Repository.Implementation
{
    internal class FileDataRepository : IDataRepository
    {
        private static string PATH = "../../../../worldcup.sfg.io/";
        private EnumGender gender;
        private List<Match> cachedMatches;
        private List<Team> cachedTeams;
        private List<Result> cachedResults;
        private List<GroupedResult> cachedGroupedResults;
        private Dictionary<string, string>? countries;

        public FileDataRepository(EnumGender gender)
        {
            this.gender = gender;
            cachedMatches = new List<Match>();
            cachedTeams = new List<Team>();
            cachedResults = new List<Result>();
            cachedGroupedResults = new List<GroupedResult>();
            countries = null;
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

        public Task<List<Match>> GetMatches()
        {
            return Task.Run(() =>
            {
                if (cachedMatches.Count == 0)
                {
                    cachedMatches.Clear();
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Read("matches")).ToHashSet().ToList());
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
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Read("matches")));
                }

                if (fifaCountryCode == null) return cachedMatches;

                return cachedMatches.Where(x =>
                {
                    return x.HomeTeam.Code.Equals(fifaCountryCode.ToUpper())
                            || x.AwayTeam.Code.Equals(fifaCountryCode.ToUpper());
                }).ToHashSet().ToList();
            });
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
                    cachedMatches.AddRange(JsonConvert.DeserializeObject<List<Match>>(Read("matches")));
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

        public Task<Result?> GetTeamResult(string fifaCountryCode)
        {
            return Task.Run(async () =>
            {
                List<Result> list = await GetTeamsResults();
                Result result = list.FirstOrDefault(x => x.FifaCode.Equals(fifaCountryCode), null);

                return result;
            });
        }

        public Task<List<Team>> GetTeams()
        {
            return Task.Run(() =>
            {
                if (cachedTeams.Count == 0)
                {
                    cachedTeams.Clear();
                    cachedTeams.AddRange(JsonConvert.DeserializeObject<List<Team>>(Read("teams")));
                }

                return cachedTeams ?? new List<Team>();
            });
        }

        public Task<List<GroupedResult>> GetTeamsGroupResults()
        {
            return Task.Run(() =>
            {
                if (cachedGroupedResults.Count == 0)
                {
                    cachedGroupedResults.Clear();
                    cachedGroupedResults.AddRange(JsonConvert.DeserializeObject<List<GroupedResult>>(Read("/teams/group_results")));
                }

                return cachedGroupedResults ?? new List<GroupedResult>();
            });
        }

        public Task<List<Result>> GetTeamsResults()
        {
            return Task.Run(() =>
            {
                if (cachedResults == null || cachedResults.Count == 0)
                {
                    cachedResults.Clear();
                    cachedResults = JsonConvert.DeserializeObject<List<Result>>(Read("/teams/results"));
                }

                return cachedResults ?? new List<Result>();
            });
        }

        /// UTILS

        private string Read(string file)
        {
            return File.ReadAllText(PATH + "/" + gender.ToString().ToLower() + "/" + file + ".json");
        }
    }
}
