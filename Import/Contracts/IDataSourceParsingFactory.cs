using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Import.Model;

namespace Import.Contracts
{
    interface IDataSourceParsingFactory
    {
        IDataSourceParsingService Create(SourceType dataSourceType);
    }
}
