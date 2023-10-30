using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace library.Controllers
{
    public class DefaultController : Controller
    {
        AuthorManager  authorManager = new AuthorManager(new EFAuthorDal(), new libraryDBContext());
        BookManager bookManager = new BookManager(new EfBookDal(), new libraryDBContext()   );

        private  readonly IAuthorService _authorService;
        private libraryDBContext _appDbContext;
        private  IBookService _bookService;


        public DefaultController(IAuthorService authorService,libraryDBContext appdbContext,IBookService bookService)
        {
        _bookService       = bookService;
            _authorService = authorService;
            _appDbContext = appdbContext;
        }
        public IActionResult BookList()
        {
            //var booklist1 = _appDbContext.Books.Include(x => x.Author).ToList();
            var booklist=_bookService.GetAllBooksAllEntity();  
            //List<Author> authorList = _authorService.GetAll(); 
            return View(booklist);
        }

       
    }
}
