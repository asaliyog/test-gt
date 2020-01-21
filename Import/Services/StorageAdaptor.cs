using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Contracts;
using Import.Model;

namespace Import.Services
{
    class StorageAdaptor : IStorageAdoptor
    {
        public void StoreInventory(List<Product> inventory)
        {
            //Mysql Adptee methods tro staore dataa
            //after 3 moths mongodb adaptee to store data
            throw new NotImplementedException();
        }
    }
}
