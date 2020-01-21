using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using System.IO;

namespace Import.Services
{
    public class CommandValidation : ICommandValidation
    {
        public string [] Validate(string command) {
            if (string.IsNullOrEmpty(command)) {
                throw new Exception("command is blac");
            }
            string[] commandInParts = command.Split(' ');
            if (commandInParts.Length > 3 || commandInParts.Length < 3) {
                throw new Exception("command is not in correct format");
            }
            if (commandInParts[0] != "import") {
                throw new Exception("command is not in correct format");
            }
            //bellow code can be used to validate the csv download url
            //if (!IsValidUri(commandInParts[2])) {
                //throw new Exception("Not a valid URI");
            //}
            return commandInParts;
        }
        public bool IsValidUri(string uri) {
            Uri uriResult;
            return Uri.TryCreate(uri, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        public bool FileExist(string path)
        {
            return File.Exists(path);
        }
    }
}
