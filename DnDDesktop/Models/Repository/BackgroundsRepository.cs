using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;

namespace DnDDesktop.Models.Repository
{
    public class BackgroundsRepository
    {
        string ws1 = "https://localhost:7153/api/Background/";

        public List<Background> GetBackgrounds()
        {
            return MakeRequest<List<Background>>(ws1, null, "GET", "application/json");
        }

        public Background GetBackground(string id)
        {
            return MakeRequest<Background>(ws1 + id, null, "GET", "application/json");
        }

        public Background CreateBackground(Background background)
        {
            return MakeRequest<Background>(ws1, background, "POST", "application/json");
        }

        public Background UpdateBackground(Background background)
        {
            return MakeRequest<Background>(ws1 + background.Id, background, "PUT", "application/json");
        }

        public Background DeleteBackground(string id)
        {
            return MakeRequest<Background>(ws1 + id, null, "DELETE", "application/json");
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
