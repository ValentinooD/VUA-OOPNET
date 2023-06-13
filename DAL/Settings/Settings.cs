using DAL.JSON;
using DAL.Repository;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DAL.Settings
{
    public class Settings
    {
        [JsonProperty("lang")]
        public string Language { get; set; } = "en";

        [JsonProperty("data_repo_type")]
        [JsonConverter(typeof(DataRepositoryTypeConverter))]
        public EnumDataRepositoryType DataRepositoryType { get; set; } = EnumDataRepositoryType.API;

        [JsonProperty("gender")]
        [JsonConverter(typeof(GenderConverter))]
        public EnumGender Gender { get; set; } = EnumGender.Men;

        [JsonProperty("favourite_team_fifa_code")]
        public string? FavouriteTeam { get; set; }

        [JsonProperty("favourite_player_names")]
        public HashSet<string> FavouritePlayerNames { get; set; } = new HashSet<string>();

        [JsonProperty("profile_pictures")]
        public Dictionary<string, string> ProfilePictures { get; set; } = new Dictionary<string, string>();

        ///////// WPF ONLY \\\\\\\\\\
        [JsonProperty("wpf_fav_away_team")] 
        public string? FavouriteAwayTeam { get; set; }

        [JsonProperty("resolution")]
        public Resolution? Resolution { get; set; } = new Resolution();
    }

    public class Resolution
    {
        public WindowState State { get; set; } = WindowState.Normal;
        public int? Width { get; set; }
        public int? Height { get; set; }

        public enum WindowState
        {
            Normal, FullScreen, SaveLast
        }
    }
}
