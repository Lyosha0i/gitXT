using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1._1.Entities
{
    public class User
    {
        public Guid ID { get; set; }

        public DateTime DateOfBirth { get; set; }//User: Id,Name, DateOfBirth, Age

        public string Name { get; set; }
        public int Age { get; set; }

        public User(Guid Id, DateTime date, string name)
        {
            ID = Id;
            DateOfBirth = date;
            Name= name;
            Age = DateTime.Today.Year - DateOfBirth.Year + (Math.Sign(DateTime.Compare(new DateTime(DateTime.Now.Year, DateOfBirth.Month, DateOfBirth.Day), DateTime.Today) * -1 + 1) - 1);
            Console.WriteLine(Age);
            Debug.WriteLine(Age);
        }

        public User(DateTime date, string name)
        {
            ID = Guid.NewGuid();
            DateOfBirth = date;
            Name = name;
            Age = DateTime.Today.Year - DateOfBirth.Year+ (Math.Sign(DateTime.Compare(new DateTime(DateTime.Now.Year,DateOfBirth.Month,DateOfBirth.Day) , DateTime.Today) * -1 + 1) - 1);
            Console.WriteLine(Age);
            Debug.WriteLine(Age);
        }

        public User()
        {

        }

        public void Edit(DateTime date=default, string name=null)
        {
            if (date != default) DateOfBirth = date;
            if (name != null) Name = name;
        }
    }
}
