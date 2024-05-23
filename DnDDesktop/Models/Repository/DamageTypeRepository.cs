using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class DamageTypeRepository
    {
        string urlDamageType = "https://api.mounthein.es/api/DamageType/";

        public List<DamageType> GetDamageTypes()
        {
            return MakeRequest<List<DamageType>>(urlDamageType, null, "GET", "application/json");
        }

        public DamageType GetDamageType(string id)
        {
            return MakeRequest<DamageType>(urlDamageType + id, null, "GET", "application/json");
        }

        public DamageType CreateDamageType(DamageType damageType)
        {
            return MakeRequest<DamageType>(urlDamageType, damageType, "POST", "application/json");
        }

        public DamageType UpdateDamageType(DamageType damageType)
        {
            return MakeRequest<DamageType>(urlDamageType + damageType.Id, damageType, "PUT", "application/json");
        }

        public DamageType DeleteDamageType(string id)
        {
            return MakeRequest<DamageType>(urlDamageType + id, null, "DELETE", "application/json");
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