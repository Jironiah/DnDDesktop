using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class RacesRepository
    {
        string urlRaces = "https://localhost:7153/api/Race/";

        public List<Race> GetAbilityScores()
        {
            return MakeRequest<List<Race>>(urlRaces, null, "GET", "application/json");
        }

        public Race GetAbilityScore(string id)
        {
            return MakeRequest<Race>(urlRaces + id, null, "GET", "application/json");
        }

        public Race CreateAbilityScore(Race race)
        {
            return MakeRequest<Race>(urlRaces, race, "POST", "application/json");
        }

        public Race UpdateAbilityScore(Race race)
        {
            return MakeRequest<Race>(urlRaces + race.Id, race, "PUT", "application/json");
        }

        public Race DeleteAbilityScore(string id)
        {
            return MakeRequest<Race>(urlRaces + id, null, "DELETE", "application/json");
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
