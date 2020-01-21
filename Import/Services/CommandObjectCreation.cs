using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Import.Model;
using System.IO;

namespace Import.Services
{
public class CommandObjectCreation : ICommandObjectCreation
    {
        public ICommandValidation commandValidation { get; set; }

        public CommandObjectCreation(ICommandValidation _commandValidation) {
            commandValidation = _commandValidation;

        }
        public Command CreateCommand(string command)
        {
            string[] commandInParts = commandValidation.Validate(command);
            Command commandObject = new Command();
            commandObject.DataSourceName = commandInParts[1];
            commandObject.DataSourcePath = commandInParts[2];
            commandObject.DataSourcePathType = GetPathType(commandInParts[2]);
            commandObject.DataSourceType = GetDataSourceType(commandInParts[2]);

            return commandObject;
        }
        private PathType GetPathType(string path) {
            if (commandValidation.FileExist(path))
            {
                return PathType.LocalPath;
            }
            else if (commandValidation.IsValidUri(path)) {
                throw new NotImplementedException("URL for datasource feature havent been implemented yet");
            }
            throw new Exception("unknown path type");
        }
        private SourceType GetDataSourceType(string path) {
           string extention =  Path.GetExtension(path);

            if (extention == ".json")
            {
                return SourceType.JSON;
            }
            else if (extention == ".yml") {
                return SourceType.YML;
            }
            throw new Exception("unknown extention type");
        }
    }
}
