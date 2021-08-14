using Biblioseca.Model.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioseca.Model
{
    public class Lending
    {

        public virtual int Id { get; set; }
        public virtual Book Book { get; set; }
        public virtual Member Member { get; set; }
        public virtual DateTime LendDate { get; set; }
        public virtual DateTime ReturnDate { get; set; }

        /// <summary>
        /// Creates the specified book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <param name="partner">The partner.</param>
        /// <returns></returns>
        public static Lending Create(Book book, Member member)
        {
            Ensure.NotNull(book, "Borrow.Book no puede ser nulo. ");
            Ensure.NotNull(member, "Borrow.Partner no puede ser nulo. ");

            Lending lending = new Lending
            {
                Book = book,
                Member = member,
                LendDate = DateTime.Now
            };

            return lending;
        }

        public virtual void Returned()
        {
            ReturnDate = DateTime.Now;
        }

    }
}
