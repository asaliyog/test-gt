﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import.Model;

namespace Import.Contracts
{
    interface IStorageAdoptor
    {
        void StoreInventory(List<Product> inventory);
    }
}
