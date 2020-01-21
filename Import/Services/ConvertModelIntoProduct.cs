using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Import.Model;
using Newtonsoft.Json.Linq;

namespace Import.Services
{
    class ConvertModelIntoProduct : IConvertModelIntoProduct
    {
        public List<Product> ConvertCSVIntoProduct(List<string> csvObject)
        {
            throw new NotImplementedException();
        }

        public List<Product> ConvertJsonIntoProduct(JObject jsonObject)
        {
            throw new NotImplementedException();
        }

        public List<Product> ConvertYMLIntoProduct(JObject ymlObject)
        {
            throw new NotImplementedException();
        }
    }
}
