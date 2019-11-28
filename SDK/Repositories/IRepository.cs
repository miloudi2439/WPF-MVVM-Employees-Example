using MVVM_FIRST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    public interface IRepository<T>
    {
   

        IEnumerable<T> GetAll();
        void Add(T obj);
        void Remove(T obj);
        void Update(T obj, int Id);
    }
}
