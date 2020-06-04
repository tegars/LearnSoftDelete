using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftDeleted.EntityFramework.Entities
{
    public class Category : BaseEntity
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public virtual List<Product> Products { set; get; }
    }
}
