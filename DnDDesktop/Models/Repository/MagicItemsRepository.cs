using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class MagicItemsRepository
    {
        string urlMagicItems = "https://api.mounthein.es/api/MagicItem/";

        public List<MagicItem> GetMagicItems()
        {
            return MakeRequest<List<MagicItem>>(urlMagicItems, null, "GET", "application/json");
        }

        public MagicItem GetMagicItem(string id)
        {
            return MakeRequest<MagicItem>(urlMagicItems + id, null, "GET", "application/json");
        }

        public MagicItem CreateMagicItem(MagicItem magicItems)
        {
            return MakeRequest<MagicItem>(urlMagicItems, magicItems, "POST", "application/json");
        }

        public MagicItem UpdateMagicItem(MagicItem magicItems)
        {
            return MakeRequest<MagicItem>(urlMagicItems + magicItems.Id, magicItems, "PUT", "application/json");
        }

        public MagicItem DeleteMagicItems(string id)
        {
            return MakeRequest<MagicItem>(urlMagicItems + id, null, "DELETE", "application/json");
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
