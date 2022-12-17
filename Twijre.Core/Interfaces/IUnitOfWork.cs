using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twijre.EF.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Twijre.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Customer> Customers { get; }
        IBaseRepository<Invoice> Invoices { get; }
        
        int Complete();


    }
}
