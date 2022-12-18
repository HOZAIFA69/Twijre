using System.ComponentModel.DataAnnotations;
using Twijre.API.Dtos.Invoice;

namespace Twijre.API.Dtos.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<InvoicesDto> Invoices { get; set; }
    }
}
