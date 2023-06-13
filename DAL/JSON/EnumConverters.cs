using DAL.Models;
using DAL.Repository;
using Newtonsoft.Json;

namespace DAL.JSON
{
    internal class DataRepositoryTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t.IsEnum;

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch(value)
            {
                case "api":
                    return EnumDataRepositoryType.API;
                case "file":
                    return EnumDataRepositoryType.FILE;
            }

            throw new Exception("Cannot unmarshal '" + value + "' with DataRepositoryTypeConverter");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EnumDataRepositoryType)untypedValue;
            if (value == EnumDataRepositoryType.API)
            {
                serializer.Serialize(writer, "api");
                return;
            }
            else if (value == EnumDataRepositoryType.FILE)
            {
                serializer.Serialize(writer, "file");
                return;
            }


            throw new Exception("Cannot marshal '" + value + "' with DataRepositoryTypeConverter");
        }

        public static readonly DataRepositoryTypeConverter Singleton = new DataRepositoryTypeConverter();
    }

    internal class GenderConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t.IsEnum;

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch(value)
            {
                case "men":
                    return EnumGender.Men;
                case "women":
                    return EnumGender.Women;
            }

            throw new Exception("Cannot unmarshal '" + value + "' with GenderConverter");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EnumGender)untypedValue;
            if (value == EnumGender.Men)
            {
                serializer.Serialize(writer, "men");
                return;
            }
            else if (value == EnumGender.Women)
            {
                serializer.Serialize(writer, "women");
                return;
            }

            throw new Exception("Cannot marshal '" + value + "' with GenderConverter");
        }

        public static readonly GenderConverter Singleton = new GenderConverter();
    }

    internal class TacticsConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Tactics) || t == typeof(Tactics?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "3-4-2-1":
                    return Tactics.The3421;
                case "3-4-3":
                    return Tactics.The343;
                case "3-5-2":
                    return Tactics.The352;
                case "4-2-3-1":
                    return Tactics.The4231;
                case "4-3-2-1":
                    return Tactics.The4321;
                case "4-3-3":
                    return Tactics.The433;
                case "4-4-2":
                    return Tactics.The442;
                case "4-5-1":
                    return Tactics.The451;
                case "5-3-2":
                    return Tactics.The532;
                case "5-4-1":
                    return Tactics.The541;
            }
            throw new Exception("Cannot unmarshal type Tactics - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Tactics)untypedValue;
            switch (value)
            {
                case Tactics.The3421:
                    serializer.Serialize(writer, "3-4-2-1");
                    return;
                case Tactics.The343:
                    serializer.Serialize(writer, "3-4-3");
                    return;
                case Tactics.The352:
                    serializer.Serialize(writer, "3-5-2");
                    return;
                case Tactics.The4231:
                    serializer.Serialize(writer, "4-2-3-1");
                    return;
                case Tactics.The4321:
                    serializer.Serialize(writer, "4-3-2-1");
                    return;
                case Tactics.The433:
                    serializer.Serialize(writer, "4-3-3");
                    return;
                case Tactics.The442:
                    serializer.Serialize(writer, "4-4-2");
                    return;
                case Tactics.The451:
                    serializer.Serialize(writer, "4-5-1");
                    return;
                case Tactics.The532:
                    serializer.Serialize(writer, "5-3-2");
                    return;
                case Tactics.The541:
                    serializer.Serialize(writer, "5-4-1");
                    return;
            }
            throw new Exception("Cannot marshal type Tactics - " + value);
        }

        public static readonly TacticsConverter Singleton = new TacticsConverter();
    }

    internal class TypeOfEventConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeOfEvent) || t == typeof(TypeOfEvent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "goal":
                    return TypeOfEvent.Goal;
                case "goal-own":
                    return TypeOfEvent.GoalOwn;
                case "goal-penalty":
                    return TypeOfEvent.GoalPenalty;
                case "red-card":
                    return TypeOfEvent.RedCard;
                case "substitution-in":
                    return TypeOfEvent.SubstitutionIn;
                case "substitution-out":
                    return TypeOfEvent.SubstitutionOut;
                case "yellow-card":
                    return TypeOfEvent.YellowCard;
                case "yellow-card-second":
                    return TypeOfEvent.YellowCardSecond;
            }
            throw new Exception("Cannot unmarshal type TypeOfEvent - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeOfEvent)untypedValue;
            switch (value)
            {
                case TypeOfEvent.Goal:
                    serializer.Serialize(writer, "goal");
                    return;
                case TypeOfEvent.GoalOwn:
                    serializer.Serialize(writer, "goal-own");
                    return;
                case TypeOfEvent.GoalPenalty:
                    serializer.Serialize(writer, "goal-penalty");
                    return;
                case TypeOfEvent.RedCard:
                    serializer.Serialize(writer, "red-card");
                    return;
                case TypeOfEvent.SubstitutionIn:
                    serializer.Serialize(writer, "substitution-in");
                    return;
                case TypeOfEvent.SubstitutionOut:
                    serializer.Serialize(writer, "substitution-out");
                    return;
                case TypeOfEvent.YellowCard:
                    serializer.Serialize(writer, "yellow-card");
                    return;
                case TypeOfEvent.YellowCardSecond:
                    serializer.Serialize(writer, "yellow-card-second");
                    return;
            }
            throw new Exception("Cannot marshal type TypeOfEvent - " + value);
        }

        public static readonly TypeOfEventConverter Singleton = new TypeOfEventConverter();
    }

    internal class PositionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Position) || t == typeof(Position?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Defender":
                    return Position.Defender;
                case "Forward":
                    return Position.Forward;
                case "Goalie":
                    return Position.Goalie;
                case "Midfield":
                    return Position.Midfield;
            }
            throw new Exception("Cannot unmarshal type Position - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Position)untypedValue;
            switch (value)
            {
                case Position.Defender:
                    serializer.Serialize(writer, "Defender");
                    return;
                case Position.Forward:
                    serializer.Serialize(writer, "Forward");
                    return;
                case Position.Goalie:
                    serializer.Serialize(writer, "Goalie");
                    return;
                case Position.Midfield:
                    serializer.Serialize(writer, "Midfield");
                    return;
            }
            throw new Exception("Cannot marshal type Position - " + value);
        }

        public static readonly PositionConverter Singleton = new PositionConverter();
    }

    internal class StageNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(StageName) || t == typeof(StageName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Final":
                    return StageName.Final;
                case "First stage":
                case "First Stage":
                    return StageName.FirstStage;
                case "Play-off for third place":
                    return StageName.PlayOffForThirdPlace;
                case "Quarter-finals":
                case "Quarter-final":
                    return StageName.QuarterFinals;
                case "Round of 16":
                    return StageName.RoundOf16;
                case "Semi-finals":
                case "Semi-final":
                    return StageName.SemiFinals;
                case "Match for third place":
                    return StageName.MatchForThirdPlace;
            }
            throw new Exception("Cannot unmarshal type StageName - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (StageName)untypedValue;
            switch (value)
            {
                case StageName.Final:
                    serializer.Serialize(writer, "Final");
                    return;
                case StageName.FirstStage:
                    serializer.Serialize(writer, "First stage");
                    return;
                case StageName.PlayOffForThirdPlace:
                    serializer.Serialize(writer, "Play-off for third place");
                    return;
                case StageName.QuarterFinals:
                    serializer.Serialize(writer, "Quarter-finals");
                    return;
                case StageName.RoundOf16:
                    serializer.Serialize(writer, "Round of 16");
                    return;
                case StageName.SemiFinals:
                    serializer.Serialize(writer, "Semi-finals");
                    return;
            }
            throw new Exception("Cannot marshal type StageName - " + value);
        }

        public static readonly StageNameConverter Singleton = new StageNameConverter();
    }

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "completed")
            {
                return Status.Completed;
            }
            throw new Exception("Cannot unmarshal type Status - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            if (value == Status.Completed)
            {
                serializer.Serialize(writer, "completed");
                return;
            }
            throw new Exception("Cannot marshal type Status - " + value);
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }

    internal class TimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Time) || t == typeof(Time?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "full-time")
            {
                return Time.FullTime;
            }
            throw new Exception("Cannot unmarshal type Time - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Time)untypedValue;
            if (value == Time.FullTime)
            {
                serializer.Serialize(writer, "full-time");
                return;
            }
            throw new Exception("Cannot marshal type Time - " + value);
        }

        public static readonly TimeConverter Singleton = new TimeConverter();
    }

    internal class DescriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Description) || t == typeof(Description?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Clear Night":
                    return Description.ClearNight;
                case "Cloudy":
                    return Description.Cloudy;
                case "Cloudy Night":
                    return Description.CloudyNight;
                case "Partly Cloudy":
                    return Description.PartlyCloudy;
                case "Partly Cloudy Night":
                    return Description.PartlyCloudyNight;
                case "Sunny":
                    return Description.Sunny;
            }
            throw new Exception("Cannot unmarshal type Description - " + value);
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Description)untypedValue;
            switch (value)
            {
                case Description.ClearNight:
                    serializer.Serialize(writer, "Clear Night");
                    return;
                case Description.Cloudy:
                    serializer.Serialize(writer, "Cloudy");
                    return;
                case Description.CloudyNight:
                    serializer.Serialize(writer, "Cloudy Night");
                    return;
                case Description.PartlyCloudy:
                    serializer.Serialize(writer, "Partly Cloudy");
                    return;
                case Description.PartlyCloudyNight:
                    serializer.Serialize(writer, "Partly Cloudy Night");
                    return;
                case Description.Sunny:
                    serializer.Serialize(writer, "Sunny");
                    return;
            }
            throw new Exception("Cannot marshal type Description - " + value );
        }

        public static readonly DescriptionConverter Singleton = new DescriptionConverter();
    }
}
