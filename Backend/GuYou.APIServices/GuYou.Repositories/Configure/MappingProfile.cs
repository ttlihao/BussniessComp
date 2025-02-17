using AutoMapper;
using GuYou.Repositories.DTOs;
using GuYou.Repositories.DTOs.UserDTO;
using GuYou.Repositories.Models;
using Microsoft.AspNetCore.Identity;

namespace GuYou.Repositories.Configure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<IdentityUser, UserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
            CreateMap<IdentityRole, RoleResponse>().ReverseMap();


            // Category
            CreateMap<Category, CategoryDto>().ReverseMap();

            // CoffeeBean
            CreateMap<CoffeeBean, CoffeeBeanDto>().ReverseMap();

            // CoffeeMix
            CreateMap<CoffeeMix, CoffeeMixDto>().ReverseMap();

            // CoffeeMixDetail
            CreateMap<CoffeeMixDetail, CoffeeMixDetailDto>().ReverseMap();

            // Discount
            CreateMap<Discount, DiscountDto>().ReverseMap();

            // Inventory
            CreateMap<Inventory, InventoryDto>().ReverseMap();

            // Order
            CreateMap<Order, OrderDto>().ReverseMap();

            // OrderDetail
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            // Packaging
            CreateMap<Packaging, PackagingDto>().ReverseMap();

            // Payment
            CreateMap<Payment, PaymentDto>().ReverseMap();

            // Review
            CreateMap<Review, ReviewDto>().ReverseMap();

            // ShippingDetail
            CreateMap<ShippingDetail, ShippingDetailDto>().ReverseMap();

            // Supplier
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }

}
