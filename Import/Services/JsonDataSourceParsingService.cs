using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;
using Import.Model;

namespace Import.Services
{
    class JsonDataSourceParsingService : IDataSourceParsingService
    {
        private IConvertModelIntoProduct convertModelIntoProduct { get; set; }
        public JsonDataSourceParsingService(IConvertModelIntoProduct _convertModelIntoProduct) {
            convertModelIntoProduct = _convertModelIntoProduct;
        }
        public List<Product> Parse(string path)
        {
            JObject data = null;
            using (StreamReader file = File.OpenText(path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                 data= (JObject)JToken.ReadFrom(reader);
                //parse and show output on console

            }
            return convertModelIntoProduct.ConvertJsonIntoProduct(data);
            throw new NotImplementedException();
        }
    }
}
