using System.Collections.Generic;
using Biblioseca.Model;
using NHibernate;
using NHibernate.Criterion;

namespace Biblioseca.DataAccess.Lendings
{
    public class LendingDao : Dao<Lending>, ILendingDao
    {
        public LendingDao(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        public virtual IEnumerable<Lending> GetLendingsByBookId(int bookId)
        {
            ICriteria criteria = this.Session
                .CreateCriteria<Lending>();

            criteria.CreateCriteria("Book")
                .Add(Restrictions.Eq("Id", bookId));

            return criteria.List<Lending>();
        }

        public virtual IEnumerable<Lending> GetLendings(int bookId, int memberId)
        {
            ICriteria criteria = this.Session
                .CreateCriteria<Lending>();

            criteria.CreateCriteria("Book")
                .Add(Restrictions.Eq("Id", bookId));

            criteria.CreateCriteria("Member")
                .Add(Restrictions.Eq("Id", memberId));

            criteria.Add(Restrictions.Eq("ReturnDate", null));

            return criteria.List<Lending>();
        }

        public virtual Lending GetLending(int bookId, int memberId)
        {
            ICriteria criteria = this.Session
                .CreateCriteria<Lending>();

            criteria.CreateCriteria("Book")
                .Add(Restrictions.Eq("Id", bookId));

            criteria.CreateCriteria("Member")
                .Add(Restrictions.Eq("Id", memberId));

            criteria.Add(Restrictions.Eq("ReturnDate", null));

            return criteria.UniqueResult<Lending>();
        }

    }

   
}
