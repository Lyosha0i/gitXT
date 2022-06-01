using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._3.BLL.Interfaces;
using Task8._1._3.DAL.Interfaces;
using Task8._1._1.Entities;

namespace Task8._1._3.BLL
{
    public class UsersAndAwardsLogic : IUsersAndAwardsBll
    {
        private IAwardsDAO _awardsJsonDal;
        private IUsersDAO _usersJsonDal;
        private IUsersAwardsDAO _usersAwardsJsonDal;

        public UsersAndAwardsLogic(IAwardsDAO awardsJsonDao, IUsersDAO usersJsonDao, IUsersAwardsDAO usersAwardsJsonDao)
        {
            _awardsJsonDal = awardsJsonDao;
            _usersJsonDal = usersJsonDao;
            _usersAwardsJsonDal = usersAwardsJsonDao;
        }
        public Award AddAward(string title)=> _awardsJsonDal.AddAward(title);

        public User AddUser(DateTime date, string name) => _usersJsonDal.AddUser(date,name);

        public UserAward AddUserAward(User user, Award award) => _usersAwardsJsonDal.AddUserAward(user,award);

        public void EditAward(Guid id, string title) => _awardsJsonDal.EditAward(id,title);

        public void EditUser(Guid id, DateTime date, string name) => _usersJsonDal.EditUser(id,date,name);

        public Award GetAward(Guid id) => _awardsJsonDal.GetAward(id);

        public IEnumerable<Award> GetAwards() => _awardsJsonDal.GetAwards();

        public User GetUser(Guid id) => _usersJsonDal.GetUser(id);

        public UserAward GetUserAward(Guid id) => _usersAwardsJsonDal.GetUserAward(id);

        public IEnumerable<User> GetUsers() => _usersJsonDal.GetUsers();

        public void RemoveAward(Guid id) => _awardsJsonDal.RemoveAward(id);

        public void RemoveUser(Guid id) => _usersJsonDal.RemoveUser(id);

        public void RemoveUserAward(Guid id) => _usersAwardsJsonDal.RemoveUserAward(id);


    }
}
