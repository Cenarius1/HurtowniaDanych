using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWH.Storage.Interface {
    public interface IGenericRepository<TDomain> {
        TDomain Insert(TDomain dbo);
        void SaveChanges();
    }
}
