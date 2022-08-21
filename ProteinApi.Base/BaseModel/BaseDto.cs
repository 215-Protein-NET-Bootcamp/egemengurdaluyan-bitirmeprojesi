using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Base
{
    public abstract class BaseDto
    {
        public DateTime CreatedAt { get; set; }


        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

    }
}
