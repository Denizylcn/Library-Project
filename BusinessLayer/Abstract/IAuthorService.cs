using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService:IGenericService<Author>
    {
        public Author CheckAuthor(string name);
       public int AddAuthorAndGetId(Author author);

    }
}
