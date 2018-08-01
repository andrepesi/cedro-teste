using Credo.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Application.Interfaces
{
    public interface IAppService<TViewModel, TKeyType>
    {
        #region [ Transactions ]
        ValidationResult Add(TViewModel entity);
        ValidationResult Update(TViewModel entity);
        ValidationResult Delete(TKeyType entity);
        #endregion

        #region [ Queries ]
        IEnumerable<TViewModel> SelectAll();
        TViewModel SelectById(TKeyType id);
        #endregion
    }
}
