using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Repository
{
    public class WeaponPropertiesRepository
    {
        string urlWeaponProperties = "https://api.mounthein.es/api/WeaponProperty/";

        public List<WeaponProperty> GetWeaponProperties()
        {
            return MakeRequest<List<WeaponProperty>>(urlWeaponProperties, null, "GET", "application/json");
        }

        public WeaponProperty GetWeaponProperty(string id)
        {
            return MakeRequest<WeaponProperty>(urlWeaponProperties + id, null, "GET", "application/json");
        }

        public WeaponProperty CreateWeaponProperty(WeaponProperty weapongProperty)
        {
            return MakeRequest<WeaponProperty>(urlWeaponProperties, weapongProperty, "POST", "application/json");
        }

        public WeaponProperty UpdateWeaponProperty(WeaponProperty weapongProperty)
        {
            return MakeRequest<WeaponProperty>(urlWeaponProperties + weapongProperty.Id, weapongProperty, "PUT", "application/json");
        }

        public WeaponProperty DeleteWeaponProperty(string id)
        {
            return MakeRequest<WeaponProperty>(urlWeaponProperties + id, null, "DELETE", "application/json");
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
