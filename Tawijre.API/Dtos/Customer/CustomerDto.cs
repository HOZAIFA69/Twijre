using System.ComponentModel.DataAnnotations;

namespace Twijre.API.Dtos.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
