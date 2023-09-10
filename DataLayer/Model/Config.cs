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
        public FileLoadingType LoadingType { get; set; }
        public Language PreferredLanguage { get; set; }
        public DesiredPriority Priority { get; set; }
        public string FavoriteRepFifaCode { get; set; }
        public List<string> FavoritePlayers { get; set; }
        public string LocalPath { get; set; }
        public bool IsFirstSetup { get; set; }
        public double WPFWidth { get; set; }
        public double WPFHeight { get; set; }


        public IDictionary<string,string> ImagePaths { get; set; }

        public Config() {
            FavoritePlayers = new List<string>();
            LocalPath= string.Empty;
            LoadingType= FileLoadingType.WEB;
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

    }
}
