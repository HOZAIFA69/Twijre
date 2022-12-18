using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twaijri.Core.Interfaces;
using Twijre.EF;
using Twijre.EF.Models;

namespace Twaijri.Core.Repositories
{
    public class SpecialCustomersRepository : ISpecialCustomersRepository
    {
        private readonly ApplicationDbContext _context;

        public SpecialCustomersRepository( ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> GetCustomersIncludeInvoice(int id)
        {
            return await _context.Customers.Where(c => c.Id == id).Include(i => i.Invoices).FirstOrDefaultAsync();
        }
    }
}
