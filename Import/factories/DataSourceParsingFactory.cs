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
    class DataSourceParsingFactory : IDataSourceParsingFactory
    { 
        private IServiceProvider serviceProvider { get; set; }
        public DataSourceParsingFactory(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
        }

        public IDataSourceParsingService Create(SourceType dataSourceType)
        {
            if (dataSourceType == SourceType.JSON) {
                return serviceProvider.GetService<JsonDataSourceParsingService>();
            }
            else if (dataSourceType == SourceType.YML)
            {
                return serviceProvider.GetService<YMLDataSourceParsingService>();
            }
            else
            {
                return serviceProvider.GetService<CSVDataSourceParsingService>();
            }
        }
    }
}
