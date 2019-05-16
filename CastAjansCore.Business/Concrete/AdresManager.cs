﻿using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class AdresManager : ManagerRepositoryBase<Adres>, IAdresServis
    {
        public AdresManager(IEntitiyRepository<Adres> dal) : base(dal)
        {
        }
    }
}