using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository
{
    public class ClassesRepository
    {
        string ws1 = "https://localhost:7153/api/Classes/";

        public List<Classes> GetClasses()
        {
            return MakeRequest<List<Classes>>(ws1, null, "GET", "application/json");
        }

        public Classes GetClass(string id)
        {
            return MakeRequest<Classes>(ws1 + id, null, "GET", "application/json");
        }

        public Classes CreateClass(Classes classes)
        {
            return MakeRequest<Classes>(ws1, classes, "POST", "application/json");
        }

        public Classes UpdateClass(Classes classes)
        {
            return MakeRequest<Classes>(ws1 + classes.Id, classes, "PUT", "application/json");
        }

        public Classes DeleteClass(string id)
        {
            return MakeRequest<Classes>(ws1 + id, null, "DELETE", "application/json");
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
