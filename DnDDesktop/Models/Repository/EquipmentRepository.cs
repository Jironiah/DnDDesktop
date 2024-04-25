using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class EquipmentRepository
    {
        string urlEquipment = "https://localhost:7153/api/Equipment/";

        public List<Equipment> GetEquipments()
        {
            return MakeRequest<List<Equipment>>(urlEquipment, null, "GET", "application/json");
        }

        public Equipment GetEquipment(string id)
        {
            return MakeRequest<Equipment>(urlEquipment + id, null, "GET", "application/json");
        }

        public Equipment CreateEquipment(Equipment equipment)
        {
            return MakeRequest<Equipment>(urlEquipment, equipment, "POST", "application/json");
        }

        public Equipment UpdateEquipment(Equipment equipment)
        {
            return MakeRequest<Equipment>(urlEquipment + equipment.Id, equipment, "PUT", "application/json");
        }

        public Equipment DeleteEquipment(string id)
        {
            return MakeRequest<Equipment>(urlEquipment + id, null, "DELETE", "application/json");
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