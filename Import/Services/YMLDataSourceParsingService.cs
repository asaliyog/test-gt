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
    class YMLDataSourceParsingService : IDataSourceParsingService
    {
        private IConvertModelIntoProduct convertModelIntoProduct { get; set; }
        public YMLDataSourceParsingService(IConvertModelIntoProduct _convertModelIntoProduct)
        {
            convertModelIntoProduct = _convertModelIntoProduct;
        }
        public List<Product> Parse(string path)
        {
            //read yml from path then retirve jobject which goes into bellow line for conversion
            return convertModelIntoProduct.ConvertYMLIntoProduct(new JObject());
        }
    }
}
