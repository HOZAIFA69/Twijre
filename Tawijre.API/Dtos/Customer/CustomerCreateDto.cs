using System.ComponentModel.DataAnnotations;

namespace Twijre.API.Dtos.Customer
{
    public class CustomerCreateDto
    {
        [Required] public string Name { get; set; }
        [Required] public string Phone { get; set; }
    }
}
