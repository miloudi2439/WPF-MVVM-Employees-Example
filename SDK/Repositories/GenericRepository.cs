using MVVM_FIRST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SDK.Model
{
    public class GenericRepository<T>: IRepository<T>  where T:  class
    {
        protected WorkDbContext _db;
        internal DbSet<T> dbSet;

        public GenericRepository(WorkDbContext db)
        {
            this._db = db;
            this.dbSet = _db.Set<T>();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public int NumberOfRows()
        {

            var v  = _db.Set<T>().Count();
            return v; 
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Add(T obj)
        {
            _db.Set<T>().Add(obj);
        }

        public void Remove(T obj)
        {
            _db.Set<T>().Remove(obj);
        }

        public void Update(T New, int Id)
        {
            T Old = GetByID(Id); 
            _db.Entry(Old).CurrentValues.SetValues(New);
        }


    }
}
