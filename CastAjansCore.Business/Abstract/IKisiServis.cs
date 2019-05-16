﻿using Calbay.Core.Business;
using CastAjansCore.Entity;
using System.Collections.Generic;

namespace CastAjansCore.Business.Abstract
{
    public interface IKisiServis : IServiceRepository<Kisi>
    {
        List<Kisi> GetByKanGrubu(EnuKanGrubu kanGrubu);

    }
}