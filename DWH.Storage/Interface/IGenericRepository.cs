using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DWH.Storage.Interface {
    public interface IGenericRepository<TDomain> {
        TDomain Insert(TDomain dbo);
        List<TDomain> SelectAll();
        List<TDomain> Find(Expression<Func<TDomain, bool>> prediction);
        void SaveChanges();
    }
}
