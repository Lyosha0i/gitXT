using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._1.BLL;
using Task8._1._1.BLL.Interfaces;
using Task8._1._1.DAL;
using Task8._1._1.DAL.Interfaces;

namespace Task8._1._1.Dependencies
{
    public class DependencyResolver
    {
        #region SINGLETON

        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();

                return _instance;
            }
        }

        private DependencyResolver()
        {

        }

        #endregion

        private IAwardsDAO _awardsJsonDal;
        private IUsersDAO _usersJsonDal;
        private IUsersAwardsDAO _usersAwardsJsonDal;
        public IAwardsDAO AwardsJsonDAO
        {
            get
            {
                if (_awardsJsonDal == null)
                    _awardsJsonDal = new AwardsJsonDAO();

                return _awardsJsonDal;
            }
        }
        public IUsersAwardsDAO UsersAwardsJsonDAO
        {
            get
            {
                if (_usersAwardsJsonDal == null)
                    _usersAwardsJsonDal = new UsersAwardsJsonDAO();

                return _usersAwardsJsonDal;
            }
        }
        public IUsersDAO UsersJsonDAO
        {
            get
            {
                if (_usersJsonDal == null)
                    _usersJsonDal = new UsersJsonDAO();

                return _usersJsonDal;
            }
        }

        private IUsersAndAwardsBll _usersAndAwardsBll;
        public IUsersAndAwardsBll UsersAndAwardsBll
        {
            get
            {
                if (_usersAndAwardsBll == null)
                    _usersAndAwardsBll= new UsersAndAwardsLogic(AwardsJsonDAO,UsersJsonDAO,UsersAwardsJsonDAO);

                return _usersAndAwardsBll;
            }
        }
            // => _usersAndAwardsBll ??= new UsersAndAwardsLogic(NotesDAO);
    }
}
