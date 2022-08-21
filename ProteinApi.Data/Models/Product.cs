using ProteinApi.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class Product : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Trademark { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public int AccountId { get; set; }
        public int OfferedValue { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSolid { get; set; }
        public byte[] Image { get; set; }
    }
}
