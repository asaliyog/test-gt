using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts; 


namespace Import.Services
{
    class YMLDataSourceValidationService : IDataSourceValidationService
    {
        public bool ValidateDataSourse(string path) {
            return true;
            //not implemented but would have converted YML into json and then validated the schema same way i did in 
            //YMLDataSourceValidationService
        }
    }
}
