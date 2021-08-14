using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioseca.Model
{
    public class Member
    {
        public Member()
        {
            Lendings = new HashSet<Lending>();
        }

        public virtual int Id { get; set; }
               
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Username { get; set; }

        public virtual ISet<Lending> Lendings { get; set; }

    }
}
