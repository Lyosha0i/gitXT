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
    public class UsersJsonDAO : IUsersDAO
    {
        public const string JsonFilesPath = @"G:\Users\";//@"\Files\Users";
        public User AddUser(DateTime date, string name)
        {
            var user = new User(date,name);

            string json = JsonConvert.SerializeObject(user);

            File.WriteAllText(GetFileFullNameById(user.ID), json);

            return user;
        }
        private string GetFileFullNameById(Guid id) => JsonFilesPath + id + ".json";

        public User GetUser(Guid id)
        {
            if (!File.Exists(GetFileFullNameById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!",
                        id, JsonFilesPath));

            var textContent = File.ReadAllText(GetFileFullNameById(id));

            return JsonConvert.DeserializeObject<User>(textContent);
        }

        public void RemoveUser(Guid id)
        {
            if (File.Exists(GetFileFullNameById(id)))
                File.Delete(GetFileFullNameById(id));

            else throw new FileNotFoundException(
                string.Format("File with name {0} at path {1} isn't created!", id + ".json", JsonFilesPath));
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> users=new List<User>();
            DirectoryInfo di = new DirectoryInfo(JsonFilesPath);
            if (!di.Exists)
                Directory.CreateDirectory(JsonFilesPath);
            FileInfo[] usersJsons = di.GetFiles("*.json");
            foreach (var item in usersJsons)
                users.Add(JsonConvert.DeserializeObject<User>(File.ReadAllText(item.FullName)));
            //users.Add(new User(DateTime.Now,"A"));
            return users;
        }

        public void EditUser(Guid id, DateTime date=default, string name=null)
        {
            if (!File.Exists(GetFileFullNameById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!",
                        id, JsonFilesPath));

            User user = JsonConvert.DeserializeObject<User>(File.ReadAllText(GetFileFullNameById(id)));

            user.Edit(date,name);

            File.WriteAllText(GetFileFullNameById(user.ID), JsonConvert.SerializeObject(user));
        }
    }
}
