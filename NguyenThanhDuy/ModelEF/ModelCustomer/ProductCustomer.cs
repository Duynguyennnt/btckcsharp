using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.ModelCustomer
{
    public class ProductCustomer
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public decimal? UnitCost { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public string CategoryName { get; set; }
    }
}
