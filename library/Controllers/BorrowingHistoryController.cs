using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class BorrowingHistoryController : Controller
    {
        BorrowingHistoryManagement borrowingManager = new BorrowingHistoryManagement(new EFBorrowingHistory(), new libraryDBContext());
        private IBorrowingHistoryService _borrowingHistoryService;
        public BorrowingHistoryController(IBorrowingHistoryService borrowingHistoryService)
        {
            _borrowingHistoryService = borrowingHistoryService;   
        }
     
     
        public IActionResult BorrowingHistory(int id)
        {



            var borrowingBooks = _borrowingHistoryService.GetBorrowingBooks();
          
            var SelectedBook = borrowingBooks.Find(book=>book.BookId==id);
            return View(SelectedBook);
        }
    }
}
