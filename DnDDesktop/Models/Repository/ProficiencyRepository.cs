using System.Net;
using System.Text;
using Newtonsoft.Json;


namespace DnDDesktop.Models.Repository
{
    public class ProficiencyRepository
    {
        string urlProficiency = "https://api.mounthein.es/api/Proficiency/";

        public List<Proficiency> GetProficiencies()
        {
            return MakeRequest<List<Proficiency>>(urlProficiency, null, "GET", "application/json");
        }

        public Proficiency GetProficiency(string id)
        {
            return MakeRequest<Proficiency>(urlProficiency + id, null, "GET", "application/json");
        }

        public Proficiency CreateProficiency(Proficiency proficiency)
        {
            return MakeRequest<Proficiency>(urlProficiency, proficiency, "POST", "application/json");
        }

        public Proficiency UpdateProficiency(Proficiency proficiency)
        {
            return MakeRequest<Proficiency>(urlProficiency + proficiency.Id, proficiency, "PUT", "application/json");
        }

        public Proficiency DeleteProficiency(string id)
        {
            return MakeRequest<Proficiency>(urlProficiency + id, null, "DELETE", "application/json");
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
