using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IBookDal:IGenericDal<Book>
    {
        public List<Book> GetAllBooksAllEntity()
        {
            using (var context = new libraryDBContext())
            {
                return context.Books
                  .Include(x => x.BookAvailability)
                  .Include(x => x.Author)
                  .OrderBy(x => x.BookName).ToList();
            }
        }
       

    }
}
