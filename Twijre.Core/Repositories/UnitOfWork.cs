using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twijre.Core.Interfaces;
using Twijre.EF;
using Twijre.EF.Models;

namespace Twijre.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new BaseRepository<Customer>(_context);
            Invoices = new BaseRepository<Invoice>(_context);
        }
        public IBaseRepository<Customer> Customers { get; private set; }
        public IBaseRepository<Invoice> Invoices { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
