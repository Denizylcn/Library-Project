using DataAccesLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFBorrowingHistory: GenericRepository<BorrowingHistory>,IBorrowingHistoryDal
    {
        public void AddBorrowing(BorrowingHistory borrowingHistory)
        {

        }
    }
}
