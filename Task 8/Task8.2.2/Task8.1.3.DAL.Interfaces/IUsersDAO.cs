using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._1.Entities;

namespace Task8._1._3.DAL.Interfaces
{
    public interface IUsersDAO
    {
        User AddUser(DateTime date, string name);

        void RemoveUser(Guid id);

        void EditUser(Guid id, DateTime date, string name);

        User GetUser(Guid id);

        IEnumerable<User> GetUsers();
    }
}
