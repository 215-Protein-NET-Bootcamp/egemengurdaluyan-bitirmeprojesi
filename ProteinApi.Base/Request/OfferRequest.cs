using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Base
{
    public class OfferRequest
    {
        [Required]
        public int OfferId { get; set; }

        [Required]
        public int OfferPrice { get; set; }

    }
}
