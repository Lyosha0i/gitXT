using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1._1.Entities
{
    public class UserAward
    {
        public Guid ID { get; set; }
        public int UserID { get; set; }
        public int AwardID { get; set; }
        public User UserProp { get; set; }
        public Award AwardProp { get; set; }

        //public UserAward this[Guid index]
        //{
        //    get => personal[index];
        //    set => personal[index] = value;
        //}
        public UserAward(int user,int award)
        {
            UserID = user;
            AwardID = award;
        }
        public UserAward(Guid Id, User user, Award award)
        {
            ID = Id;
            UserProp = user;
            AwardProp = award;
        }
        //public UserAward(int Id, User user, Award award)
        //{
        //    ID2 = Id;
        //    UserProp = user;
        //    AwardProp = award;
        //}
        public UserAward(User user, Award award)
        {
            ID = Guid.NewGuid();
            UserProp = user;
            AwardProp = award;
        }
        public UserAward()
        {

        }
    }
}
