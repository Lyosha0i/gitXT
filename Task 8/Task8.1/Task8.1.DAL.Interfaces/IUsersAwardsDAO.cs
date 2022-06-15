using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._1.Entities;

namespace Task8._1._1.DAL.Interfaces
{
    public interface IUsersAwardsDAO
    {
        UserAward AddUserAward(User user, Award award);

        void RemoveUserAward(Guid id);

        //void EditNote(Guid id, string newText);

        UserAward GetUserAward(Guid id);

        IEnumerable<UserAward> GetUsersAwards();
    }
}
