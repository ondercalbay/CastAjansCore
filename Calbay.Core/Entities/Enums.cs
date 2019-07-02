﻿using System.ComponentModel.DataAnnotations;

namespace Calbay.Core.Entities
{
    public enum EnuRol
    {
        [Display(Name = "Admin")]
        admin = 1,

        [Display(Name = "Calısan")]
        calisan = 2
    }
}