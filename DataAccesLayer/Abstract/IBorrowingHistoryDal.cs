using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IBorrowingHistoryDal:IGenericDal<BorrowingHistory>
    {
        public List<BorrowingHistory> GetBorrowingBooks()
        {
            using (var context = new libraryDBContext())
            {
                
                return context.BorrowingHistories
                  .Include(x => x.Book)
                  .Include(x => x.Book.Author)
                  .Include(x=>x.Book.BookAvailability)
                  .Include(x => x.Member)
                  .ToList();



            }
          
            
        }

    }
}
