using ProteinApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Dto
{
    public class ProductDto
    {
        [Required]
        [Display(Name = "Id")]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public string Trademark { get; set; }

        [Required]
        public Category Category { get; set; }

        public Color Color { get; set; }

        [Required]
        public bool IsOfferable { get; set; }

        [Required]
        public bool IsSolid { get; set; }

        public int AccountId { get; set; }

        public int OfferedValue { get; set; }

        public byte[] Image { get; set; }



    }
}
