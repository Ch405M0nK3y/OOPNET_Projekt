using DAL;
using DataLayer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class ConfigRepository : IRepoConfig
    {
        public ConfigRepository(){}

        private static string? DIR; // path to resources folder
        private static string? FILE_PATH; //path to config.txt

        public Config Load(string path) 
        {
            Config data;
            CreateIfNonExistant(path);
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

        public void Save(Config config) 
        {
            string jsonString = JsonConvert.SerializeObject(config);

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

        private static void CreateIfNonExistant(string path)
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

        public string GetImage(IDictionary<string,string> ImagePaths, string name)
        {
            string path = "";
            if (ImagePaths.ContainsKey(name))
            {
                path = ImagePaths[name];
            }
            return path;
        }

        public IDictionary<string, string> AddImage(IDictionary<string,string> imagePath,string playerName, string fileName)
        {
            imagePath=RemoveImage(imagePath, playerName);
            string newPath = SaveImageToResources(fileName);
            imagePath.Add(playerName, newPath);
            return imagePath;
        }

        public IDictionary<string, string> RemoveImage(IDictionary<string, string> imagePath, string name)
        {
            if (imagePath.ContainsKey(name))
            {
                imagePath.Remove(name);
            }
            return imagePath;
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
