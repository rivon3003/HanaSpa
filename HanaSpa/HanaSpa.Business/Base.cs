using System;
using System.Collections.Generic;
using System.Text;
using RivonHouse.Business;
using RivonHouse.Infrastructure.Repository;

namespace HanaSpa.Business
{
    public class Base<TEntity> : RivonHouse.Business.Base<TEntity> where TEntity : class
    {
        #region Contructor and Properties

        private readonly IUnitOfWorkFactory<IUnitOfWork> _uowFac;

        public Base(IUnitOfWorkFactory<IUnitOfWork> uowFac)
        {
            base.UowFac = uowFac;
            _uowFac = uowFac;
        }

        #endregion Contructor and Properties
    }
}
