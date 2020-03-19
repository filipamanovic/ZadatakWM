using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Maker : BaseEntity
    {
        public string MakerName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
