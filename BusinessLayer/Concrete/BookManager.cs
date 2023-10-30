using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BookManager : IBookService

    {
        private libraryDBContext _context;
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal, libraryDBContext context)
        {
            _bookDal = bookDal;
            _context = context;

        }
        public List<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooksAllEntity()
        {
         return  _bookDal.GetAllBooksAllEntity();
        }

        public Book GetById(int id)
        {
            using (var context = new libraryDBContext())
            {
                var book = context.Books.FirstOrDefault(b => b.BookId == id);
                return book;
            }
        }
  

        public void TAdd(Book t)

        {
            int newMemberID = GenerateUniqueBookID();
      
            Book addBook = new Book
            {
                BookImgUrl = t.BookImgUrl,
                BookId = newMemberID,
                BookName = t.BookName,
                AuthorId = t.AuthorId,
                BookAvailabilityId = 1,



            };
            _bookDal.Insert(addBook);   
        }

        public void TDelete(Book t)
        {
            throw new NotImplementedException();
        }
        public int GenerateUniqueBookID()
        {
            // BorrowingID'nin en büyük mevcut değerini bulma
            int maxBookID = _context.Books.Max(b => (int?)b.BookId) ?? 0;

            // Yeni ID'yi oluşturma
            int newBookID = maxBookID + 1;

            return newBookID;
        }

        public void TUpdate(Book t)
        {

            Book updateBook = new Book
            {
                BookImgUrl = t.BookImgUrl, 
                BookId = t.BookId,
                BookName = t.BookName,
                AuthorId = t.AuthorId,
                BookAvailabilityId= t.BookAvailabilityId,   


                
            };
            _bookDal.Update(updateBook);
        }
    }
}
