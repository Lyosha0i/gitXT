using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task8._1._1.BLL.Interfaces;
using Task8._1._1.Dependencies;
using Task8._1._1.Entities;

namespace Task8._1._1
{
    class Program
    {
        public int Day(string s)
        {
            int day;
            int.TryParse(s,out day);
            return day;
        }
        static void Main(string[] args)
        {
            IUsersAndAwardsBll bll = DependencyResolver.Instance.UsersAndAwardsBll;
            //bll.AddUser(new DateTime(2020,2,29),"Lyo");
            //for(int i=0;i<360;i+=10)
            //    bll.AddUser(new DateTime(2004,8,16)+TimeSpan.FromDays(i), "Lyosha");
            //bll.AddAward("Silver");
            //foreach (var item in bll.GetUsers().ToList())
            //    bll.AddUserAward(item, bll.GetAwards().ToList()[0]);
            //bll.AddUserAward(bll.GetUsers().ToList()[0], bll.GetAwards().ToList()[0]);
            List<UserAward> usersAwards = new List<UserAward>();
            DirectoryInfo di = new DirectoryInfo(@"G:\UsersAwards\");
            if (!di.Exists)
                Directory.CreateDirectory(@"G:\UsersAwards\");
            FileInfo[] usersJsons = di.GetFiles("*.json");
            foreach (var item in usersJsons)
                usersAwards.Add(JsonConvert.DeserializeObject<UserAward>(File.ReadAllText(item.FullName)));
            foreach (var item in bll.GetUsers())
            {
                Console.WriteLine("{0} {1}",item.Name, item.Age);
                foreach (var j in usersAwards)
                {
                    if(item.ID==j.UserProp.ID)
                    Console.WriteLine(j.AwardProp.Title);
                }
                    
            }
        }
    }
}
