using System;
using System.Collections.Generic;
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
            //This formula is wrong.
            Age = DateTime.Now.Year - DateOfBirth.Year + (Math.Sign(DateTime.Now.DayOfYear + Math.Sign(59 - DateOfBirth.DayOfYear) * -1 * (29 - DateTime.DaysInMonth(2020, 2) - 28) + Math.Sign(365 - DateTime.Now.DayOfYear) * -1 * ((new DateTime(DateOfBirth.Year, 12, 31) - TimeSpan.FromDays(365)).Year - DateOfBirth.Year-1) - DateOfBirth.DayOfYear) - 1) / 2;
        }

        public User(DateTime date, string name)
        {
            ID = Guid.NewGuid();
            DateOfBirth = date;
            Name = name;
            //This formula is wrong.
            Age = DateTime.Now.Year - DateOfBirth.Year + (Math.Sign(DateTime.Now.DayOfYear + Math.Sign(59 - DateOfBirth.DayOfYear) * -1 * (29 - DateTime.DaysInMonth(2020, 2) - 28) + Math.Sign(365 - DateTime.Now.DayOfYear) * -1 * ((new DateTime(DateOfBirth.Year, 12, 31) - TimeSpan.FromDays(365)).Year - DateOfBirth.Year-1) - DateOfBirth.DayOfYear) - 1) / 2;
            //Console.WriteLine(date+" "+ ((Math.Sign(DateTime.Now.DayOfYear - DateOfBirth.DayOfYear) - 1) / 2));
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
