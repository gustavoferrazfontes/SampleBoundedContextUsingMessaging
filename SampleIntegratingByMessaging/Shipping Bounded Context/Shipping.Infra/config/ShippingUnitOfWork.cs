using SharedKernel.Interfaces;
using Shipping.Infra.Context;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shipping.Infra.config
{
    public class ShippingUnitOfWork:IUnitOfWork
    {
        private readonly ShippingContext _context;
        private bool disposed;

        public ShippingUnitOfWork(ShippingContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Rollback()
        {
            foreach (DbEntityEntry entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }
}
