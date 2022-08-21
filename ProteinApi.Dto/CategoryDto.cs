using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Dto
{
    public class CategoryDto
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
