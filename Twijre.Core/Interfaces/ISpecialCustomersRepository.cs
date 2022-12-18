using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twijre.EF.Models;

namespace Twaijri.Core.Interfaces
{
    public interface ISpecialCustomersRepository
    {
        Task<Customer> GetCustomersIncludeInvoice( int id);
    }
}
