using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category: BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category>? SubCategories { get; set; } 
        public ICollection<Product>? Products { get; set; } 
    }
}
