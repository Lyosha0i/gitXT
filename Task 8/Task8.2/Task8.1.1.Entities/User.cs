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
        public int ID2 { get; set; }

        public DateTime DateOfBirth { get; set; }//User: Id,Name, DateOfBirth, Age

        public string Name { get; set; }
        public int Age { get; set; }

        public User(Guid Id, DateTime date, string name)
        {
            ID = Id;
            DateOfBirth = date;
            Name= name;
            Age = DateTime.Now.Year-DateOfBirth.Year+(Math.Sign(DateTime.Now.DayOfYear-DateOfBirth.DayOfYear)-1)/2;//This formula is wrong.
        }
        public User(int Id, DateTime date, string name)
        {
            ID2 = Id;
            DateOfBirth = date;
            Name = name;
            Age = DateTime.Now.Year - DateOfBirth.Year + (Math.Sign(DateTime.Now.DayOfYear - DateOfBirth.DayOfYear) - 1) / 2;//This formula is wrong.
        }
        public User(int Id, DateTime date, int age, string name)
        {
            ID2 = Id;
            DateOfBirth = date;
            Name = name;
            Age = DateTime.Now.Year - DateOfBirth.Year + (Math.Sign(DateTime.Now.DayOfYear - DateOfBirth.DayOfYear) - 1) / 2;//This formula is wrong.
        }

        public User(DateTime date, string name)
        {
            ID = Guid.NewGuid();
            DateOfBirth = date;
            Name = name;
            Age = DateTime.Now.Year - DateOfBirth.Year+(Math.Sign(DateTime.Now.DayOfYear - DateOfBirth.DayOfYear) - 1) / 2;
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
