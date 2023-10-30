using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BorrowingHistoryManagement:IBorrowingHistoryService
    {

        private libraryDBContext _context;
        IBorrowingHistoryDal _borrowingHistory;
        public BorrowingHistoryManagement(IBorrowingHistoryDal borrowingHistory, libraryDBContext context)
        {
            _borrowingHistory = borrowingHistory;
            _context = context;
        }
        public int GenerateUniqueBorrowingID()
        {
            // BorrowingID'nin en büyük mevcut değerini bulma
            int maxBorrowingID = _context.BorrowingHistories.Max(b => (int?)b.BorrowingId) ?? 0;

            // Yeni benzersiz ID'yi oluşturma
            int newBorrowingID = maxBorrowingID + 1;

            return newBorrowingID;
        }
      

        public List<BorrowingHistory> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BorrowingHistory> GetBorrowingBooks()
        {
            return _borrowingHistory.GetBorrowingBooks();
        }

        public BorrowingHistory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(BorrowingHistory t)

        {
            int newBorrowingID = GenerateUniqueBorrowingID();
            BorrowingHistory newBorrowing = new BorrowingHistory
            {
                BorrowingId = newBorrowingID, 
                BookId = t.BookId,
                MemberId = t.MemberId,

                DueDate = t.DueDate,
                

               
            };

         
          
            _borrowingHistory.Insert(newBorrowing);
        }

        public void TDelete(BorrowingHistory t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(BorrowingHistory t)
        {
            throw new NotImplementedException();
        }

    

     

       

     
    }
}
