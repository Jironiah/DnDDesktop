using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnDDesktop.Models.Repository
{
    public class SpellsRepository
    {
        string urlSpells = "https://localhost:7153/api/Spell/";

        public List<Spell> GetSpells()
        {
            return MakeRequest<List<Spell>>(urlSpells, null, "GET", "application/json");
        }

        public Spell GetSpell(string id)
        {
            return MakeRequest<Spell>(urlSpells + id, null, "GET", "application/json");
        }

        public Spell CreateSpell(Spell skill)
        {
            return MakeRequest<Spell>(urlSpells, skill, "POST", "application/json");
        }

        public Spell UpdateSpell(Spell skill)
        {
            return MakeRequest<Spell>(urlSpells + skill.Id, skill, "PUT", "application/json");
        }

        public Spell DeleteSpell(string id)
        {
            return MakeRequest<Spell>(urlSpells + id, null, "DELETE", "application/json");
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
