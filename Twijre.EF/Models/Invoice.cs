using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twijre.EF.Enums;

namespace Twijre.EF.Models
{
    public class Invoice
    {
        [Key] public int Id { get; set; }
        public Customer Customer  { get; set; }
        public int CustomerId  { get; set; }
        public Decimal Value { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public  State state   { get; set; }
    }
}
