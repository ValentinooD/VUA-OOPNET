using Newtonsoft.Json;

namespace DAL.Settings
{
    public class SettingsService
    {
        private const string FILE_PATH = @"./settings.txt";

        private SettingsService()
        {
        }

        public static void Save(Settings settings)
        {
            if (settings == null) throw new NullReferenceException();

            string json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(FILE_PATH, json);
        }

        public static Settings Load()
        {
            if (!File.Exists(FILE_PATH))
            {
                return new Settings();
            }

            string content = File.ReadAllText(FILE_PATH);
            if (content == null) { return new Settings(); }
           
            Settings? settings = JsonConvert.DeserializeObject<Settings>(content);
            return (settings == null ? new Settings() : settings);
        }

        public static bool IsFirstRun()
        {
            return !File.Exists(FILE_PATH);
        }
    }
}
