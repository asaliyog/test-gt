using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Import.Model;

namespace Import.Services
{
    class ImportInventory : IImportInventory
    {
        private ICommandObjectCreation commandObjectCreation { get; set; }

        private IDataSourceValidationFactory dataSourceValidationFactory { get;set;}
        private IDataSourceParsingFactory dataSourceParsingFactory { get; set; }

        private IStorageAdoptor storageAdaptor { get; set; }
        public ImportInventory(ICommandObjectCreation _commandObjectCreation,
            IDataSourceParsingFactory _dataSourceParsingFactory,
            IDataSourceValidationFactory _dataSourceValidationFactory,
            IStorageAdoptor _storageAdaptor) {
            commandObjectCreation = _commandObjectCreation;
            dataSourceValidationFactory = _dataSourceValidationFactory;
            dataSourceParsingFactory = _dataSourceParsingFactory;
            storageAdaptor = _storageAdaptor;
        }
        public void Process(string command) {
            Progress progress = Progress.CommandObjectCreation;
            Command commandObject = new Command();
            List<Product> inventory = new List<Product>();
            while (progress != Progress.Success) {
                switch (progress) {
                    case Progress.CommandObjectCreation:
                        commandObject = commandObjectCreation.CreateCommand(command);
                        progress = Progress.DataSourceValidation;
                        break;
                    case Progress.DataSourceValidation:
                        IDataSourceValidationService dataSourceValidationService = dataSourceValidationFactory.Create(commandObject.DataSourceType);
                        dataSourceValidationService.ValidateDataSourse(commandObject.DataSourcePath);
                        progress = Progress.Parsing;
                        break;
                    case Progress.Parsing:
                        IDataSourceParsingService dataSourceParsingService = dataSourceParsingFactory.Create(commandObject.DataSourceType);
                        inventory = dataSourceParsingService.Parse(commandObject.DataSourcePath);
                        progress = Progress.Parsing;
                        break;
                    case Progress.Storage:
                        storageAdaptor.StoreInventory(inventory);
                        progress = Progress.Success;
                        break;

                }
            }
        }
        enum Progress
        {
            CommandObjectCreation,
            DataSourceValidation,
            Parsing,
            Storage,
            Success 
        }

    }
}
