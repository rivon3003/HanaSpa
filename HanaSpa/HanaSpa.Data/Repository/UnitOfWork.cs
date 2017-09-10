using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HanaSpa.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RivonHouse.Common.Constants;
using RivonHouse.Common.Data.Entity;
using RivonHouse.Common.Data.Result;
using RivonHouse.Common.Data.ViewModel.Account;
using RivonHouse.Common.Extensions;
using RivonHouse.Data.Repository;
using RivonHouse.Infrastructure.Repository;

namespace HanaSpa.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly HanaSpaContext _dbContext;
        private readonly Dictionary<Type, IGenericRepository> cachedRepositories = new Dictionary<Type, IGenericRepository>();
        private bool diposed = false;

        private ISession _session;

        public UnitOfWork(HanaSpaContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            if (cachedRepositories.ContainsKey(type))
            {
                return cachedRepositories[type] as IGenericRepository<TEntity>;
            }
            else
            {
                var repository = new GenericRepository<TEntity>(_dbContext.Set<TEntity>());
                cachedRepositories[type] = repository;
                return repository;
            }
        }

        public void Save()
        {
            TrackDataRecords();
            _dbContext.SaveChanges();
        }

        public async Task<Save> SaveAsync()
        {
            TrackDataRecords();
            try
            {
                await _dbContext.SaveChangesAsync();
                return new Save
                {
                    IsSuccessful = true,
                    Message = Messages.SaveSuccessful
                };
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new Save
                {
                    IsSuccessful = false,
                    Message = Messages.ConcurrencyOccured + "-" + ex.Message
                };
            }
            catch
            {
                return new Save
                {
                    IsSuccessful = false,
                    Message = Messages.Unknown
                };
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.diposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.diposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public HanaSpaContext GetContext()
        {
            return _dbContext;
        }

        private void TrackDataRecords()
        {
            var changeSet = _dbContext.ChangeTracker.Entries();

            if (changeSet != null)
            {
                var currentDateTime = DateTime.Now;
                Type type;

                //TODO: Remove when Login function completed
                string currentAccount = Error.NotAvailable;
                if (_session.GetObjectFromJson<Account>(SessionName.LoggedAccount) != null)
                {
                    currentAccount = _session.GetObjectFromJson<LoginViewModel>(SessionName.LoggedAccount).AccountNumber.ToString();
                }

                var changes = changeSet.Where(c => c.State != EntityState.Unchanged && c.State != EntityState.Deleted);
                foreach (var entry in changes)
                {
                    type = entry.Entity.GetType();
                    if (type.GetProperty(PropertyName.Id) != null)
                    {
                        entry.State = (int)type.GetProperty(PropertyName.Id).GetValue(entry.Entity, null) < 0
                            ? EntityState.Added : EntityState.Modified;
                    }
                    var updAtPr = type.GetProperty(PropertyName.UpdatedDate);
                    var updByPr = type.GetProperty(PropertyName.UpdatedBy);
                    var insAtPr = type.GetProperty(PropertyName.CreatedDate);
                    var insByPr = type.GetProperty(PropertyName.CreatedBy);

                    if (updAtPr != null) type.GetProperty(PropertyName.UpdatedDate).SetValue(entry.Entity, currentDateTime, null);
                    if (updByPr != null) type.GetProperty(PropertyName.UpdatedBy).SetValue(entry.Entity, currentAccount, null);

                    if (insAtPr != null && (type.GetProperty(PropertyName.CreatedDate).GetValue(entry.Entity, null) == null
                        || (DateTime)type.GetProperty(PropertyName.CreatedDate).GetValue(entry.Entity, null) == DateTime.MinValue))
                    {
                        type.GetProperty(PropertyName.CreatedDate).SetValue(entry.Entity, currentDateTime, null);
                    }
                    if (insByPr != null && type.GetProperty(PropertyName.CreatedBy).GetValue(entry.Entity, null) == null)
                    {
                        type.GetProperty(PropertyName.CreatedBy).SetValue(entry.Entity, currentAccount, null);
                    }
                    if (entry.State == EntityState.Added)
                    {
                        if (insAtPr != null) type.GetProperty(PropertyName.CreatedDate).SetValue(entry.Entity, currentDateTime, null);
                        if (insByPr != null) type.GetProperty(PropertyName.CreatedBy).SetValue(entry.Entity, currentAccount, null);
                    }
                }
            }
        }
    }
}
