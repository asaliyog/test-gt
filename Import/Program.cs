using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Import.Contracts;
using Import.Services;
using Import.factories;

namespace Import
{
    class Program
    {
        private static IServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            string command = Console.ReadLine();
            var service = _serviceProvider.GetService<IImportInventory>();
            service.Process(command);
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IImportInventory, ImportInventory>();
            collection.AddScoped<ICommandObjectCreation, CommandObjectCreation>();
            collection.AddScoped<ICommandValidation, CommandValidation>();
            collection.AddScoped<IDataSourceParsingFactory, DataSourceParsingFactory>();
            collection.AddScoped<IDataSourceValidationFactory, DataSourceValidationFactory>();
            collection.AddScoped<IDataSourceParsingService, JsonDataSourceParsingService>();
            collection.AddScoped<IDataSourceParsingService, YMLDataSourceParsingService>();
            collection.AddScoped<IDataSourceParsingService, CSVDataSourceParsingService>();
            collection.AddScoped<IDataSourceValidationService, JsonDataSourceValidationService>();
            collection.AddScoped<IDataSourceValidationService, YMLDataSourceValidationService>();
            collection.AddScoped<IDataSourceValidationService, CSVDataSourceValidationService>();
            collection.AddSingleton<JsonDataSourceParsingService>();
            collection.AddSingleton<YMLDataSourceParsingService>();
            collection.AddSingleton<CSVDataSourceParsingService>();
            //collection.AddScoped<ICommandValidation, CommandValidation>();
            //collection.AddScoped<ICommandValidation, CommandValidation>();
            //collection.AddScoped<ICommandValidation, CommandValidation>();
            //collection.AddScoped<ICommandValidation, CommandValidation>();
            // ...
            // Add other services
            // ...
            _serviceProvider = collection.BuildServiceProvider();
        }
        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
