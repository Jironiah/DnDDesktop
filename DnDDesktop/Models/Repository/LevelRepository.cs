using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class LevelRepository
    {
        string urlLevel = "https://localhost:7153/api/Level/";

        public List<Level> GetLevels()
        {
            return MakeRequest<List<Level>>(urlLevel, null, "GET", "application/json");
        }

        public Level GetLevel(string id)
        {
            return MakeRequest<Level>(urlLevel + id, null, "GET", "application/json");
        }

        public Level CreateLevel(Level level)
        {
            return MakeRequest<Level>(urlLevel, level, "POST", "application/json");
        }

        public Level UpdateLevel(Level level)
        {
            return MakeRequest<Level>(urlLevel + level.Id, level, "PUT", "application/json");
        }

        public Level DeleteLevel(string id)
        {
            return MakeRequest<Level>(urlLevel + id, null, "DELETE", "application/json");
        }

        private T MakeRequest<T>(string requestUrl, object JSONRequest, string JSONmethod, string JSONContentType)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Method = JSONmethod;

                if (JSONmethod != "GET")
                {
                    request.ContentType = JSONContentType;
                    string sb = JsonConvert.SerializeObject(JSONRequest);
                    byte[] bt = Encoding.UTF8.GetBytes(sb);
                    using (Stream st = request.GetRequestStream())
                    {
                        st.Write(bt, 0, bt.Length);
                    }
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception($"Server error (HTTP {response.StatusCode}: {response.StatusDescription}).");
                    }

                    using (StreamReader sr = new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        string strsb = sr.ReadToEnd();
                        T objResponse = JsonConvert.DeserializeObject<T>(strsb);
                        return objResponse;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default;
            }
        }
    }
}