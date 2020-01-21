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

namespace Import.Services
{
    class JsonDataSourceValidationService : IDataSourceValidationService
    {
        public bool ValidateDataSourse(string path)
        {
            string data = File.ReadAllText(path);
            string schema = File.ReadAllText("data.schema.json");

            var model = JObject.Parse(data);
            var json_schema = JSchema.Parse(schema);

            IList<string> messages;
            bool valid = model.IsValid(json_schema, out messages);

            if (!valid) {
                throw new Exception("not a valid json file ");
            }

            return valid;
        }
    }
}
