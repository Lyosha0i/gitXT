using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._1.DAL.Interfaces;
using Task8._1._1.Entities;

namespace Task8._1._1.DAL
{
    public class UsersAwardsJsonDAO : IUsersAwardsDAO
    {
        public const string JsonFilesPath = @"G:\UsersAwards\";

        public UserAward AddUserAward(User user, Award award)
        {
            var userAward = new UserAward(user,award);

            string json = JsonConvert.SerializeObject(userAward);

            File.WriteAllText(GetFileFullNameById(userAward.ID), json);

            return userAward;
        }
        private string GetFileFullNameById(Guid id) => JsonFilesPath + id + ".json";
        public UserAward GetUserAward(Guid id)
        {
            if (!File.Exists(GetFileFullNameById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!",
                        id, JsonFilesPath));

            var textContent = File.ReadAllText(GetFileFullNameById(id));

            return JsonConvert.DeserializeObject<UserAward>(textContent);
        }

        public void RemoveUserAward(Guid id)
        {
            if (File.Exists(GetFileFullNameById(id)))
                File.Delete(GetFileFullNameById(id));

            else throw new FileNotFoundException(
                string.Format("File with name {0} at path {1} isn't created!", id + ".json", JsonFilesPath));
        }

        public IEnumerable<UserAward> GetUsersAwards()
        {
            List<UserAward> usersAwards = new List<UserAward>();
            DirectoryInfo di = new DirectoryInfo(@"G:\UsersAwards\");
            if (!di.Exists)
                Directory.CreateDirectory(@"G:\UsersAwards\");
            FileInfo[] usersJsons = di.GetFiles("*.json");
            foreach (var item in usersJsons)
                usersAwards.Add(JsonConvert.DeserializeObject<UserAward>(File.ReadAllText(item.FullName)));
            //foreach (var item in new UsersJsonDAO().GetUsers())
            //{
            //    Console.WriteLine("{0} {1}", item.Name, item.Age);
            //    foreach (var j in usersAwards)
            //    {
            //        if (item.ID == j.UserProp.ID)
            //            Console.WriteLine(j.AwardProp.Title);
            //    }

            //}
            return usersAwards;
        }
    }
}
