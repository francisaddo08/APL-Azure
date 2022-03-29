using System;
using System.Collections.Generic;
using System.Linq;
using APL_Technical_Test.data;
using Microsoft.EntityFrameworkCore;

namespace APL_Technical_Test.repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
     
      
        protected ApplicationContext db { get; set; }
        public Repository(ApplicationContext cx)
        {
            db = cx;
        }
        public void Add(TEntity model)
        {
            db.Set<TEntity>().Add(model);
        }

        public TEntity GetById(DateTime Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

    
    }
}
