using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._3.DAL.Interfaces;
using Task8._1._1.Entities;

namespace Task8._1._3.DAL
{
    public class AwardsJsonDAO : IAwardsDAO
    {
        public const string JsonFilesPath = @"G:\Awards\";

        public Award AddAward(string title)
        {
            var award = new Award(title);

            string json = JsonConvert.SerializeObject(award);

            File.WriteAllText(GetFileFullNameById(award.ID), json);

            return award;
        }

        public Award GetAward(Guid id)
        {
            if (!File.Exists(GetFileFullNameById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!",
                        id, JsonFilesPath));

            var textContent = File.ReadAllText(GetFileFullNameById(id));

            return JsonConvert.DeserializeObject<Award>(textContent);
        }
        public IEnumerable<Award> GetAwards()
        {
            List<Award> awards = new List<Award>();
            DirectoryInfo di = new DirectoryInfo(JsonFilesPath);
            if (!di.Exists)
                Directory.CreateDirectory(JsonFilesPath);
            FileInfo[] usersJsons = di.GetFiles("*.json");
            foreach (var item in usersJsons)
                awards.Add(JsonConvert.DeserializeObject<Award>(File.ReadAllText(item.FullName)));
            //users.Add(new User(DateTime.Now,"A"));
            return awards;
        }
        private string GetFileFullNameById(Guid id) => JsonFilesPath + id + ".json";

        public void RemoveAward(Guid id)
        {
            if (File.Exists(GetFileFullNameById(id)))
                File.Delete(GetFileFullNameById(id));

            else throw new FileNotFoundException(
                string.Format("File with name {0} at path {1} isn't created!", id + ".json", JsonFilesPath));
        }

        public void EditAward(Guid id, string title = null)
        {
            if (!File.Exists(GetFileFullNameById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!",
                        id, JsonFilesPath));

            Award award= JsonConvert.DeserializeObject<Award>(File.ReadAllText(GetFileFullNameById(id)));

            award.Edit(title);

            File.WriteAllText(GetFileFullNameById(award.ID), JsonConvert.SerializeObject(award));
        }
    }
}
