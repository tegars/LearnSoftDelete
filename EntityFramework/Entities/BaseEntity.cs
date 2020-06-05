using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftDeleted.EntityFramework.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { set; get; }
        public DateTime? CreatedAt { set; get; }
        public DateTime? UpdatedAt { set; get; }
        public int CreatedBy { set; get; }
        public int UpdatedBy { set; get; }
        public bool IsDeleted { set; get; }
    }
}
