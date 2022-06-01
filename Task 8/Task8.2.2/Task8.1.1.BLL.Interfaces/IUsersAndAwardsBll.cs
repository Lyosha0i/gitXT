using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._1.Entities;

namespace Task8._1._1.BLL.Interfaces
{
    public interface IUsersAndAwardsBll
    {
        User AddUser(DateTime date, string name);
        Award AddAward(string title);
        UserAward AddUserAward(User user, Award award);

        void RemoveUser(Guid id);
        void RemoveAward(Guid id);
        void RemoveUserAward(Guid id);

        //void EditNote(Guid id, string newText);

        User GetUser(Guid id);
        Award GetAward(Guid id);
        UserAward GetUserAward(Guid id);

        IEnumerable<User> GetUsers();
        IEnumerable<Award> GetAwards();
        IEnumerable<UserAward> GetUsersAwards();
    }
}
