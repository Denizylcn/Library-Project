using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static library.Controllers.BorrowingController;

 namespace library.Controllers
{
     public class BookController : Controller
    {
        BookManager bookmanager = new BookManager(new EfBookDal(), new libraryDBContext() );
        AuthorManager authormanager = new AuthorManager(new EFAuthorDal(), new libraryDBContext());
        private IBookService _bookService;
        private IAuthorService _authorService;
        public BookController(IBookService bookService,IAuthorService authorService)
        {
            _authorService = authorService;

            _bookService = bookService;
        }
        public class YourCustomViewModel
        {
            public Book Books { get; set; }
            public List<Author> Authors { get; set; }
        }
        [HttpGet]
        public IActionResult RegisterBook()
        {
         
       
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterBook(Book book,Author a)
            
        {
              // Yazarın mevcut olup olmadığını kontrol et
                var existingAuthor = _authorService.CheckAuthor(book.Author.AuthorFullName);

                if (existingAuthor == null)
                {
                    // Yazar mevcut değilse yeni bir yazar kaydı oluştur
               int newAuthorID=_authorService.AddAuthorAndGetId(book.Author);

                    // Oluşturulan yazarın Id'sini al

                    book.AuthorId = newAuthorID;

                   
                }
                else
                {
                    // Yazar mevcutsa, var olan yazarın Id'sini kullan
                    book.AuthorId = existingAuthor.AuthorId;
                    
                }

                   if (book.BookPicture != null && book.BookPicture.Length > 0)
                   {
                      var fileName = Guid.NewGuid().ToString() + Path.GetExtension(book.BookPicture.FileName);
                      var filePath = Path.Combine("wwwroot/img", fileName);
                         book.BookImgUrl = fileName;
             

                       using (var stream = new FileStream(filePath, FileMode.Create))
                       {
                           book.BookPicture.CopyTo(stream);
                       }

            
                   }

                     _bookService.TAdd(book);

                   return RedirectToAction("BookList", "Default");
               }
              
              
            
        }
    }

