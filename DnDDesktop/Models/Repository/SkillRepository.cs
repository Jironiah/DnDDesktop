using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace DnDDesktop.Models.Repository
{
    public class SkillRepository
    {
        string urlSkill = "https://localhost:7153/api/Skill/";

        public List<Skill> GetSkills()
        {
            return MakeRequest<List<Skill>>(urlSkill, null, "GET", "application/json");
        }

        public Skill GetSkill(string id)
        {
            return MakeRequest<Skill>(urlSkill + id, null, "GET", "application/json");
        }

        public Skill CreateSkill(Skill skill)
        {
            return MakeRequest<Skill>(urlSkill, skill, "POST", "application/json");
        }

        public Skill UpdateSkill(Skill skill)
        {
            return MakeRequest<Skill>(urlSkill + skill.Id, skill, "PUT", "application/json");
        }

        public Skill DeleteSkill(string id)
        {
            return MakeRequest<Skill>(urlSkill + id, null, "DELETE", "application/json");
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
