using DAL.JSON;
using Newtonsoft.Json;

namespace DAL.Models
{
    public class Team
    {

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("goals")]
        public long? Goals { get; set; }

        [JsonProperty("penalties")]
        public long? Penalties { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long? GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        public override string ToString()
        {
            return Country + " (" + FifaCode + ")";
        }
    }

    public class TeamEvent
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("type_of_event")]
        [JsonConverter(typeof(TypeOfEventConverter))]
        public TypeOfEvent TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }

    public partial class TeamStatistics
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("attempts_on_goal")]
        public long? AttemptsOnGoal { get; set; }

        [JsonProperty("on_target")]
        public long? OnTarget { get; set; }

        [JsonProperty("off_target")]
        public long? OffTarget { get; set; }

        [JsonProperty("blocked")]
        public long? Blocked { get; set; }

        [JsonProperty("woodwork")]
        public long? Woodwork { get; set; }

        [JsonProperty("corners")]
        public long? Corners { get; set; }

        [JsonProperty("offsides")]
        public long? Offsides { get; set; }

        [JsonProperty("ball_possession")]
        public long? BallPossession { get; set; }

        [JsonProperty("pass_accuracy")]
        public long? PassAccuracy { get; set; }

        [JsonProperty("num_passes")]
        public long? NumPasses { get; set; }

        [JsonProperty("passes_completed")]
        public long? PassesCompleted { get; set; }

        [JsonProperty("distance_covered")]
        public long? DistanceCovered { get; set; }

        [JsonProperty("balls_recovered")]
        public long? BallsRecovered { get; set; }

        [JsonProperty("tackles")]
        public long? Tackles { get; set; }

        [JsonProperty("clearances")]
        public long? Clearances { get; set; }

        [JsonProperty("yellow_cards")]
        public long? YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public long? RedCards { get; set; }

        [JsonProperty("fouls_committed")]
        public long? FoulsCommitted { get; set; }

        [JsonProperty("tactics")]
        [JsonConverter(typeof(TacticsConverter))]
        public Tactics Tactics { get; set; }

        [JsonProperty("starting_eleven")]
        public Player[] StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public Player[] Substitutes { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long? ShirtNumber { get; set; }

        [JsonProperty("position")]
        [JsonConverter(typeof(PositionConverter))]
        public Position Position { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   ShirtNumber == player.ShirtNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ShirtNumber);
        }
    }

    public enum TypeOfEvent { Goal, GoalOwn, GoalPenalty, RedCard, SubstitutionIn, SubstitutionOut, YellowCard, YellowCardSecond };

    public enum Position { Defender, Forward, Goalie, Midfield };

    public enum Tactics { The3421, The343, The352, The4231, The4321, The433, The442, The451, The532, The541 };

}
