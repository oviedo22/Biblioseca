using Biblioseca.DataAccess.Authors;
using Biblioseca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthorService
    {

        private readonly AuthorDao authorDao;

        public AuthorService(AuthorDao authorDao)
        {
            this.authorDao = authorDao;
        }

        public IEnumerable<Author> GetAll()
        {
            return this.authorDao.GetAll();
        }

    }
}
