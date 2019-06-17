﻿using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class ProjeEditDto
    {
        public ProjeEditDto()
        {
            Proje = new Proje();
            Kullanicilar = new List<SelectListItem>();
            Proje.ProjeKarakterleri = new List<ProjeKarakter>();
        }
        public Proje Proje { get; set; }

        public List<SelectListItem> Kullanicilar { get; set; }

    }
}
