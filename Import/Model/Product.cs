using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Import.Model
{
    class Product
    {
        public string Categories { get; set; }

        public string Name { get; set; }

        public SocialMedia Social { get; set; }
    }
    class SocialMedia { 
        public SocialMediaType TypeOfSocialMedia { get; set; }
        public string handle { get; set; }
    }
    enum SocialMediaType { 
        Twitter
    }
}
