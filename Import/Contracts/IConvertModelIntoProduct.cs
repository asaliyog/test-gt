using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Model;
using Newtonsoft.Json.Linq;

namespace Import.Contracts
{
    interface IConvertModelIntoProduct
    {
        List<Product> ConvertJsonIntoProduct(JObject jsonObject);

        List<Product> ConvertYMLIntoProduct(JObject ymlObject);

        List<Product> ConvertCSVIntoProduct(List<string> csvObject);
    }
}
