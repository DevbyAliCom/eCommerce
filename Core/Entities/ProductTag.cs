using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductTag
    {
        public Guid ProductId { get; set; }
        public required Product Product { get; set; }
        public Guid TagId { get; set; }
        public required Tag Tag { get; set; }
    }
}
