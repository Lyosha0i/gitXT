using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8._1._1.Entities;

namespace Task8._1._3.DAL.Interfaces
{
    public interface IAwardsDAO
    {
        Award AddAward(string title);

        void RemoveAward(Guid id);

        void EditAward(Guid id, string title);

        Award GetAward(Guid id);

        IEnumerable<Award> GetAwards();
    }
}
