using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Model;

namespace Import.Contracts
{
   public  interface ICommandObjectCreation
    {
        Command CreateCommand(string command);
    }
}
