using Twijre.EF.Enums;

namespace Twijre.API.Dtos.Invoice
{
    public class InvoiceCreateDto
    {
        public int CustomerId { get; set; }
        public Decimal InvoiceValue { get; set; }
        public State state { get; set; }
    }
}
