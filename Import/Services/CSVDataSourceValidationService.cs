using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;

namespace Import.Services
{
    class CSVDataSourceValidationService : IDataSourceValidationService
    {
        bool IDataSourceValidationService.ValidateDataSourse(string path)
        {
            throw new NotImplementedException();
        }
    }
}
