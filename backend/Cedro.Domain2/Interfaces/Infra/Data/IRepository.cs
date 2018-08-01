using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Domain.Interfaces.Infra.Data
{
    public interface IRepository<TEntity, TKeyType>
    {
        #region [ Transactions ]
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKeyType id);
        #endregion
        
        #region [ Queries ]
        IEnumerable<TEntity> SelectAll();
        TEntity SelectById(TKeyType id);
        #endregion

    }
}
