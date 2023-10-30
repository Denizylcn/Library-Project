using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {


        public void Delete(T t)
        {
            using var c = new libraryDBContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var c = new libraryDBContext();
            return c.Set<T>().ToList();

        }

        public void Insert(T t)
        {
            using var c = new libraryDBContext();
            c.Add(t);
            c.SaveChanges();

        }

        public void Update(T t)
        {
            using var c = new libraryDBContext();
            c.Update(t);    
            c.SaveChanges() ;   
        }
    }
}
