using AutoMapper;
using Twijre.API.Dtos.Customer;
using Twijre.API.Dtos.Invoice;
using Twijre.EF.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Twijre.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer ,CustomerCreateDto>().ReverseMap();
            CreateMap<Customer , CustomerDto>().ReverseMap();
            CreateMap<Customer , CustomerUpdateDto>().ReverseMap();

            CreateMap<Invoice, InvoiceCreateDto>().ReverseMap();
            CreateMap<Invoice, InvoicesDto>().ReverseMap();
            CreateMap<Invoice, InvoiceUpdateDto>().ReverseMap();


        }
    }
}
