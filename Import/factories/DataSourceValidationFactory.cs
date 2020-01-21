using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Import.Model;
using Microsoft.Extensions.DependencyInjection;
using Import.Services;

namespace Import.factories
{
    class DataSourceValidationFactory : IDataSourceValidationFactory
    { 
        private IServiceProvider serviceProvider { get; set; }
        public DataSourceValidationFactory(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        public IDataSourceValidationService Create(SourceType dataSourceType)
        {
            if (dataSourceType == SourceType.JSON) {
                return serviceProvider.GetService<JsonDataSourceValidationService>();
            }
            else if (dataSourceType == SourceType.YML)
            {
                return serviceProvider.GetService<YMLDataSourceValidationService>();
            }
            else
            {
                return serviceProvider.GetService<CSVDataSourceValidationService>();
            }
        }
    }
}
