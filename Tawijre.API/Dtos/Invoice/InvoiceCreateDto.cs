using Twijre.EF.Enums;

namespace Twijre.API.Dtos.Invoice
{
    public class InvoiceCreateDto
    {
        public int CustomerId { get; set; }
        public Decimal Value { get; set; }
        public State state { get; set; }
    }
}
