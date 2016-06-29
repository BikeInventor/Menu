using System;
using Menu.DAL.Core.Interfaces;
using Menu.DAL.Repositories;
using Menu.DAL.RepositoryInterfaces;

namespace Menu.DAL.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MenuDbContext db = new MenuDbContext();
        private IMenuItemRepository _menuRepository;
        private bool _disposed = false;

        public IMenuItemRepository MenuItems => 
            _menuRepository ?? (_menuRepository = new MenuItemRepository(db));

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
