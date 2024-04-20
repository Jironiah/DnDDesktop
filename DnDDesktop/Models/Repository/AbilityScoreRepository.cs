using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class AbilityScoreRepository
    {
        string urlAbilityScore = "https://localhost:7153/api/AbilityScore";

        public List<AbilityScore> GetAbilityScores()
        {
            return MakeRequest<List<AbilityScore>>(urlAbilityScore, null, "GET", "application/json");
        }

        public AbilityScore GetAbilityScore(string id)
        {
            return MakeRequest<AbilityScore>(urlAbilityScore + id, null, "GET", "application/json");
        }

        public AbilityScore CreateAbilityScore(AbilityScore abilityScore)
        {
            return MakeRequest<AbilityScore>(urlAbilityScore, abilityScore, "POST", "application/json");
        }

        public AbilityScore UpdateAbilityScore(AbilityScore abilityScore)
        {
            return MakeRequest<AbilityScore>(urlAbilityScore + abilityScore.Id, abilityScore, "PUT", "application/json");
        }

        public AbilityScore DeleteAbilityScore(string id)
        {
            return MakeRequest<AbilityScore>(urlAbilityScore + id, null, "DELETE", "application/json");
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
