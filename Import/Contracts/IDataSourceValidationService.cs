﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Contracts
{
    interface IDataSourceValidationService
    {
        bool ValidateDataSourse(string path);
    }
}
