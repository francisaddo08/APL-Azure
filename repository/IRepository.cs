using System;
using System.Collections.Generic;

namespace APL_Technical_Test.repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity model);

        TEntity GetById(DateTime cretatedDateTime);

        
    }
}
