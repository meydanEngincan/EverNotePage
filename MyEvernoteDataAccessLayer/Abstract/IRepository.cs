using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteDataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        // Listeleme metodu generic yaptık bu sayede bütün entitylerimiz için tek tek yazmaya gerek duymadan aynı metotdan faydalanabileceğiz.
        List<T> List();
        IQueryable<T> ListIQueryable();
        List<T> List(Expression<Func<T, bool>> where);
        int Insert(T obj);
        int Update(T obj);
        int Delete(T obj);
        int Save();
        T Find(Expression<Func<T, bool>> where);
    }
}
