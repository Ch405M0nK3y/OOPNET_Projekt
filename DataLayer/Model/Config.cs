using DataLayer.Model;
using DataLayer.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public enum FileLoadingType { JSON, WEB }
    public enum Language { HR, EN }
    public enum DesiredPriority { Men, Women }

    public class Config
    {
        private static string? DIR; // path to resources
        private static string? FILE_PATH; //path to config.txt
        public FileLoadingType LoadingType { get; set; }
        public Language PreferredLanguage { get; set; }
        public DesiredPriority Priority { get; set; }
        public string? FavoriteRepFifaCode { get; set; }
        public List<string>? FavoritePlayers { get; set; }
        public string LocalPath { get; set; }
        public bool IsFirstSetup { get; set; }
        public double WPFWidth { get; set; }
        public double WPFHeight { get; set; }


        public IDictionary<string,string> ImagePaths { get; set; }

        public Config() {
            FavoritePlayers = new List<string>();
            LocalPath= string.Empty;
            LoadingType= FileLoadingType.JSON;
            Priority = DesiredPriority.Men;
            PreferredLanguage = Language.EN;
            FavoriteRepFifaCode = "";
            IsFirstSetup= true;
            WPFWidth = 800;
            WPFHeight = 600;
            ImagePaths = new Dictionary<string,string>();
        }

        public override string ToString()
            => System.Text.Json.JsonSerializer.Serialize(this);

        private static void SetPath(string path)
        {
            if (DIR == null)
            {
                try
                {
                    DIR = path;

                    FILE_PATH = Path.Combine(DIR, "config.txt");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void CreateIfNonExistant(string path)
        {
            SetPath(path);
            if (!File.Exists(FILE_PATH))
            {
                try
                {
                    
                    File.Create(FILE_PATH).Close();

                    Config config = new Config();

                    string jsonString = JsonConvert.SerializeObject(config);

                    File.WriteAllText(FILE_PATH, jsonString);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static Config LoadConfig(string path)
        {
            CreateIfNonExistant(path);
            Config data = default;
            try
            {
                SetPath(path);

                string jsonString = File.ReadAllText(FILE_PATH);

                data = JsonConvert.DeserializeObject<Config>(jsonString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }

        public static void SaveConfig(Object JSONObject)
        {

            string jsonString = JsonConvert.SerializeObject(JSONObject);

            try
            {
                File.WriteAllText(FILE_PATH, jsonString);
                Console.WriteLine("JSON data saved to file successfully!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddPlayer(Player player) {
            if (FavoritePlayers?.Count==3)
            {
                Console.WriteLine("Nema, Niente, Nada");
                return;
            }
            FavoritePlayers.Add(player.Name);
        }

        public void ClearPlayers()
        {
            FavoritePlayers.Clear();
        }

        public string GetImage(string name) 
        {
            string path = "";
            if (ImagePaths.ContainsKey(name))
            {
                path = ImagePaths[name];
            }
            return path;
        }

        public void RemoveImage(string name) 
        {
            if (ImagePaths.ContainsKey(name))
            {
                ImagePaths.Remove(name);
            }
        }

        public void AddImage(string playerName,string fileName) {
            RemoveImage(playerName);
            string newPath = SaveImageToResources(fileName);
            ImagePaths.Add(playerName, newPath);
        }

        public void ClearImages() {
            ImagePaths.Clear();
        }

        public string SaveImageToResources(string fileName)
        {
            string newPath = Path.Combine(DIR, Path.GetFileName(fileName));

            try
            {
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }

                File.Copy(fileName, newPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newPath;
        }
    }
}
