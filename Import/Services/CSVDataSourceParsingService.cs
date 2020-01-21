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
    class CSVDataSourceParsingService : IDataSourceParsingService
    {
        private IConvertModelIntoProduct convertModelIntoProduct { get; set; }
        public CSVDataSourceParsingService(IConvertModelIntoProduct _convertModelIntoProduct)
        {
            convertModelIntoProduct = _convertModelIntoProduct;
        }
        public List<Product> Parse(string path)
        {
            //read CSV from path then retirve array of strings which goes into bellow line for conversion

            return convertModelIntoProduct.ConvertCSVIntoProduct(new List<string>());
        }
    }
}
