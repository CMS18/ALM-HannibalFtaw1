using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlaming1_ALM.ViewModels
{
    public class TransferViewModel
    {
        [Required]
        [Display(Name = "From account")]
        public int FromAccountId { get; set; }

        [Required]
        [Display(Name = "To account")]
        public int ToAccountId { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
