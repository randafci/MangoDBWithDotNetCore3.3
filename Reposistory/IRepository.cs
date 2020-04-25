using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Data.Repository
{
   public interface IRepository<T,K> where T: class
    {
        T Add(T item);

      

        void Update(K id,T item);


       
        T GetById(K id);

        List<T> GetAll();
    }
}
