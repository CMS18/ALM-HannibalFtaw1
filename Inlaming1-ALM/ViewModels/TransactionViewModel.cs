using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlaming1_ALM.ViewModels
{
    public class TransactionViewModel
    {
        //public string ErrorMessage { get; set; }
        //[Required]
        //public DepositViewModel DepositModel { get; set; }
        //[Required]
        //public WithdrawViewModel WithdrawModel { get; set; }


        [Required]
        [Display(Name = "Account number")]
        public int WithdrawalAccountId { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal WithdrawalAmount { get; set; }

        public string WithdrawalErrorMessage { get; set; }

        public string WithdrawalSuccessMessage { get; set; }


        [Required]
        [Display(Name = "Account number")]
        public int DepositAccountId { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal DepositAmount { get; set; }

        public string DepositErrorMessage { get; set; }

        public string DepositSuccessMessage { get; set; }

    }
}
