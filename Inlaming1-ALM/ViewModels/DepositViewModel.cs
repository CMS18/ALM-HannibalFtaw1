﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlaming1_ALM.ViewModels
{
    public class DepositViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
