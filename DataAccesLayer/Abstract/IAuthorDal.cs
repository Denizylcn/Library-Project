using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IAuthorDal:IGenericDal<Author>
    {
        public Author CheckAuthor(string fullName)
        {
            using (var context = new libraryDBContext())
            {

                Author existingAuthor = context.Authors.FirstOrDefault(a => a.AuthorFullName == fullName);
                return existingAuthor;
            }
        }
        public int AddAuthorAndGetId(Author author)
        {

            return author.AuthorId;

        }
    }
}
