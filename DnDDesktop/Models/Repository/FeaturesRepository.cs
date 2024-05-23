using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class FeaturesRepository
    {
        string urlFeature = "https://api.mounthein.es/api/Feature/";

        public List<Feature> GetFeatures()
        {
            return MakeRequest<List<Feature>>(urlFeature, null, "GET", "application/json");
        }

        public Feature GetFeature(string id)
        {
            return MakeRequest<Feature>(urlFeature + id, null, "GET", "application/json");
        }

        public Feature CreateFeature(Feature feature)
        {
            return MakeRequest<Feature>(urlFeature, feature, "POST", "application/json");
        }

        public Feature UpdateFeature(Feature feature)
        {
            return MakeRequest<Feature>(urlFeature + feature.Id, feature, "PUT", "application/json");
        }

        public Feature DeleteFeature(string id)
        {
            return MakeRequest<Feature>(urlFeature + id, null, "DELETE", "application/json");
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
