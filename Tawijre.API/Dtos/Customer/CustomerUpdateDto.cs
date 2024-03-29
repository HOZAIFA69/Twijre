﻿using System.ComponentModel.DataAnnotations;

namespace Twijre.API.Dtos.Customer
{
    public class CustomerUpdateDto
    {
        [Required] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Phone { get; set; }
    }
}
