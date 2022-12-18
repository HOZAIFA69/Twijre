using System.ComponentModel.DataAnnotations;
using Twijre.EF.Enums;

namespace Twijre.API.Dtos.Invoice
{
    public class InvoiceUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public int CustomerId { get; set; }
        [Required] public Decimal InvoiceValue { get; set; }
        public State state { get; set; }
    }
}
