using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product:BaseEntity
    {

   
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Decimal Price { get; set; }
        public string? PictureUrl { get; set; } 
        public Guid CategoryId { get; set; }
        public string? SKU { get; set; }
        public string Brand { get; set; } = string.Empty;
        public int QtyInStock { get; set; }
        public DateTime? DateAdded { get; set; }

        public required Category Category { get; set; }

        public ICollection<ProductTag> Tags { get; set; } = [];




    }
}
