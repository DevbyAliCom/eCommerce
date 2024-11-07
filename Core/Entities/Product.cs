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
        public string PictureUrl { get; set; } =string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int QtyInStock { get; set; }


    }
}
