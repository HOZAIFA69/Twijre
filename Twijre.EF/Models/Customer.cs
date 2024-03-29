﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twijre.EF.Models
{
    public class Customer
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
