using System.Text;
using Newtonsoft.Json;
using System.Net;

namespace DnDDesktop.Models.Repository
{
    public class LanguageRepository
    {
        string ws1 = "https://localhost:7153/api/Language/";

        public List<Language> GetLanguages()
        {
            return MakeRequest<List<Language>>(ws1, null, "GET", "application/json");
        }

        public Language GetLanguage(string id)
        {
            return MakeRequest<Language>(ws1 + id, null, "GET", "application/json");
        }

        public Language CreateLanguage(Language language)
        {
            return MakeRequest<Language>(ws1, language, "POST", "application/json");
        }

        public Language UpdateLanguage(Language language)
        {
            return MakeRequest<Language>(ws1 + language.Id, language, "PUT", "application/json");
        }

        public Language DeleteLanguage(string id)
        {
            return MakeRequest<Language>(ws1 + id, null, "DELETE", "application/json");
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
