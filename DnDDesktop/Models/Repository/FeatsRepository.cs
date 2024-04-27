using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository
{
    public class FeatsRepository
    {
        string urlFeats = "https://localhost:7153/api/Feat/";

        public List<Feats> GetFeats()
        {
            return MakeRequest<List<Feats>>(urlFeats, null, "GET", "application/json");
        }

        public Feats GetFeat(string id)
        {
            return MakeRequest<Feats>(urlFeats + id, null, "GET", "application/json");
        }

        public Feats CreateFeat(Feats feat)
        {
            return MakeRequest<Feats>(urlFeats, feat, "POST", "application/json");
        }

        public Feats UpdateFeat(Feats feat)
        {
            return MakeRequest<Feats>(urlFeats + feat.Id, feat, "PUT", "application/json");
        }

        public Feats DeleteFeat(string id)
        {
            return MakeRequest<Feats>(urlFeats + id, null, "DELETE", "application/json");
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
