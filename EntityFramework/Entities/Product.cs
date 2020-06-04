using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftDeleted.EntityFramework.Entities
{
    public class Product : BaseEntity
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public Guid CategoryId { set; get; }
        public virtual Category Category { set; get; }
    }
}
