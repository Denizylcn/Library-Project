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
    public class AuthorManager : IAuthorService
    {
        private libraryDBContext _context;
        IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal, libraryDBContext context)
        {
            _authorDal = authorDal;
            _context = context;
        }
        public List<Author> GetAll()
        {
         return _authorDal.GetAll();  
        }

        public Author GetById(int id)
        {
            throw new NotImplementedException();
        }
        public int GenerateUniqueAuthorID()
        {
            
            int maxAuthorID = _context.Authors.Max(b => (int?)b.AuthorId) ?? 0;

            // Yeni ID'yi oluşturma
            int newAuthorID = maxAuthorID + 1;

            return newAuthorID;
        }

        public Author CheckAuthor(string fullName)
        {
          
            return _authorDal.CheckAuthor(fullName);  
        }

        public void TAdd(Author t)

        {
            int newMemberID = GenerateUniqueAuthorID();

            Author addAuthor = new Author
            {
                AuthorFullName = t.AuthorFullName,
                  AuthorId=newMemberID,  
            


            };
          
            _authorDal.Insert(addAuthor);
            
        }
        public int AddAuthorAndGetId(Author author)
        {
            int newAuthorId = GenerateUniqueAuthorID();

            Author addAuthor = new Author
            {
                AuthorFullName = author.AuthorFullName,
                AuthorId = newAuthorId
            };

            _authorDal.Insert(addAuthor);

            return newAuthorId;
        }

        public void TDelete(Author t)
        {
            _authorDal.Delete(t);
        }

        public void TUpdate(Author t)
        {
            _authorDal.Update(t);
        }

      
    }
}
