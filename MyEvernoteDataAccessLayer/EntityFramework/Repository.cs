using MyEvernoteCommon;
using MyEvernoteDataAccessLayer;
using MyEvernoteDataAccessLayer.Abstract;
using MyEvernoteEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteDataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase,IRepository<T> where T : class
    {
       // private DatabaseContext db;
        private DbSet<T> _objectSet;

        public Repository()
        {
         //   db=RepositoryBase.CreateContext();
            _objectSet = context.Set<T>();
        }

        // Listeleme metodu generic yaptık bu sayede bütün entitylerimiz için tek tek yazmaya gerek duymadan aynı metotdan faydalanabileceğiz.
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public IQueryable<T> ListIQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }
        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);

            if(obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;
                o.CreatedOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetCurrentUserName();
            }

            return Save();
        }
        public int Update(T obj)
        {
            if (obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                o.ModifiedOn = DateTime.Now;
                o.ModifiedUsername = App.Common.GetCurrentUserName();
            }

            return Save();
        }
        public int Delete(T obj)
        {
            //if (obj is MyEntityBase)
            //{
            //    MyEntityBase o = obj as MyEntityBase;
            //    o.ModifiedOn = DateTime.Now;
            //    o.ModifiedUsername = App.Common.GetUserName();

            //}

            _objectSet.Remove(obj);
            return Save();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
