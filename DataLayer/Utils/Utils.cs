using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using DataLayer.Model;
using System.IO;
using Newtonsoft.Json;
using RestSharp.Serializers;
using System.Globalization;
using System.ComponentModel;

namespace DataLayer.Utils
{
    public static class Utils
    {

        private static readonly string? URI = "https://worldcup-vua.nullbit.hr";

        public async static Task<List<T>> Load<T>(string pathtoresource, FileLoadingType loadingType)
        {
            List<T> data = default;
            try
            {
                switch (loadingType)
                {
                    case FileLoadingType.JSON:
                        data = await LoadJSON<T>(pathtoresource);
                        break;
                    case FileLoadingType.WEB:
                        data = await LoadWEB<T>(pathtoresource);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }

        private async static Task<List<T>> LoadWEB<T>(string pathtoresource)
        {
            var client = new RestClient(URI);

            var request = new RestRequest(pathtoresource, Method.Get);

            request.AddHeader("User-Agent", "Nothing");
            request.AddHeader("Content-Type", "application/json");

            var response = await client.ExecuteAsync<List<T>>(request);

            List<T> data = JsonConvert.DeserializeObject<List<T>>(response.Content); //workaround the bad deserialize from ExecuteAsync

            return data;
        }

        private async static Task<List<T>> LoadJSON<T>(string path)
        {
            string filePath = path;

            using (StreamReader fileReader = File.OpenText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();

                // Deserialize the JSON content asynchronously
                List<T> jsonObject = (List<T>)await Task.Run(() => serializer.Deserialize(fileReader, typeof(List<T>)));

                return jsonObject;
            }
        }
    }
}
