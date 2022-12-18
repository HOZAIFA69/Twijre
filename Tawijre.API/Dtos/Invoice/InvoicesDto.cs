using System.ComponentModel.DataAnnotations;
using Twijre.EF.Enums;

namespace Twijre.API.Dtos.Invoice
{
    public class InvoicesDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Decimal InvoiceValue { get; set; }
        public DateTime InvoiceDate { get; set; }
        public State state { get; set; }
    }
}
