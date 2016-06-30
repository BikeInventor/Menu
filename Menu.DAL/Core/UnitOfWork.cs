using System;
using Menu.DAL.Core.Interfaces;
using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly MenuDbContext _db;

        public IMenuItemRepository MenuItems { get; set; }

        public UnitOfWork(MenuDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}