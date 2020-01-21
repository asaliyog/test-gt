using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Contracts
{
    public interface ICommandValidation
    {
        string [] Validate(string command);

        bool IsValidUri(string uri);

        bool FileExist(string path);
    }
}
