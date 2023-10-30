using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace library.Controllers
{
    public class BorrowingController : Controller
    {
        MemberManager membermanager = new MemberManager(new EFMemberDal(), new libraryDBContext());
        BookManager bookmanager = new BookManager(new EfBookDal(), new libraryDBContext());
        BorrowingHistoryManagement borrowingManager = new BorrowingHistoryManagement(new EFBorrowingHistory(),new libraryDBContext());
     
        private IBorrowingHistoryService _borrowingHistoryService;
        private IBookService _bookService;
        private IMemberService _memberService;
        private libraryDBContext _context;
        public BorrowingController(IBorrowingHistoryService borrowingHistoryService, IBookService bookService, IMemberService memberService, libraryDBContext context)
        {
            _context = context;
            _borrowingHistoryService = borrowingHistoryService;
            _bookService = bookService;
            _memberService = memberService;


        }
        public class YourCustomViewModel
        {
            public Book SelectedBook { get; set; }
            public List<Member> ListMembers { get; set; }
        }
        [HttpGet]
        public IActionResult BorrowingPage(int id)
        {
            var listmember = _memberService.GetAll();
            var borrowingBooks = _bookService.GetAllBooksAllEntity();
      

            var SelectedBook = borrowingBooks.Find(book => book.BookId == id);
            var viewModel = new YourCustomViewModel
            {
                SelectedBook = SelectedBook,
                ListMembers = listmember
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult BorrowingPage(BorrowingHistory bH,int selectedBookId, int selectedMemberId,Book b, int selectedBookAvailabilityId,DateTime duedate)
        {
             Book existingBook = _bookService.GetById(selectedBookId);
            Member existingMember = _memberService.GetById(selectedMemberId);

            if (existingMember == null)

            {
                ModelState.AddModelError("selectedMemberId", "Lutfen gecerli bir kullanici secin.");
                var listmember = _memberService.GetAll();
                var borrowingBooks = _bookService.GetAllBooksAllEntity();
          
                var SelectedBook = borrowingBooks.Find(book => book.BookId == selectedBookId);
                var viewModel = new YourCustomViewModel
                {
                    SelectedBook = SelectedBook,
                    ListMembers = listmember
                };
                return View(viewModel);  

            }

                bH.BookId = selectedBookId;
                bH.BookId = selectedBookId;
                bH.MemberId = selectedMemberId;
                bH.DueDate = duedate;
                b.BookId = existingBook.BookId;
                b.BookAvailabilityId = selectedBookAvailabilityId;
                b.BookImgUrl = existingBook.BookImgUrl;
                b.AuthorId = existingBook.AuthorId;
                b.BookName = existingBook.BookName;
                _borrowingHistoryService.TAdd(bH);
                _bookService.TUpdate(b);

                return RedirectToAction("BookList", "Default");



        }

    }
}
