using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8._1._1.Entities
{
    public class Award
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public Award(Guid Id, string title)
        {
            ID = Id;
            Title = title;
        }
        public Award(string title)
        {
            ID = Guid.NewGuid();
            Title = title;
        }

        public Award()
        {

        }

        public void Edit(string title=null)
        {
            if(title!=null)Title=title;
        }
    }
}
