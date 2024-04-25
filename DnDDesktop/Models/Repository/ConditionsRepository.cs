using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository
{
    internal class ConditionsRepository
    {
        string urlConditions = "https://localhost:7153/api/Conditions/";

        public List<Conditions> GetConditions()
        {
            return MakeRequest<List<Conditions>>(urlConditions, null, "GET", "application/json");
        }

        public Conditions GetCondition(string id)
        {
            return MakeRequest<Conditions>(urlConditions + id, null, "GET", "application/json");
        }

        public Conditions CreateCondition(Conditions conditions)
        {
            return MakeRequest<Conditions>(urlConditions, conditions, "POST", "application/json");
        }

        public Conditions UpdateCondition(Conditions conditions)
        {
            return MakeRequest<Conditions>(urlConditions + conditions.Id, conditions, "PUT", "application/json");
        }

        public Conditions DeleteCondition(string id)
        {
            return MakeRequest<Conditions>(urlConditions + id, null, "DELETE", "application/json");
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
