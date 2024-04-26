using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class EquipmentCategoriesRepository
    {
        string urlEquipmentCategory = "https://localhost:7153/api/EquipmentCategory/";


        public List<EquipmentCategory> GetEquipmentCategories()

        {

            return MakeRequest<List<EquipmentCategory>>(urlEquipmentCategory, null, "GET", "application/json");

        }


        public EquipmentCategory GetEquipmentCategory(string id)

        {

            return MakeRequest<EquipmentCategory>(urlEquipmentCategory + id, null, "GET", "application/json");

        }


        public EquipmentCategory CreateEquipmentCategory(EquipmentCategory equipmentCategory)

        {

            return MakeRequest<EquipmentCategory>(urlEquipmentCategory, equipmentCategory, "POST", "application/json");

        }


        public EquipmentCategory UpdateEquipmentCategory(EquipmentCategory equipmentCategory)

        {

            return MakeRequest<EquipmentCategory>(urlEquipmentCategory + equipmentCategory.Id, equipmentCategory, "PUT", "application/json");

        }


        public EquipmentCategory DeleteEquipmentCategory(string id)

        {

            return MakeRequest<EquipmentCategory>(urlEquipmentCategory + id, null, "DELETE", "application/json");

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
