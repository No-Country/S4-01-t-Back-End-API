using AutoMapper;
using S4_Back_End_API.DTOs;
using S4_Back_End_API.Models;

namespace S4_Back_End_API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Recipes
            // preview
            CreateMap<Recipe, RecipeDTO>();
            CreateMap<RecipeDTO, Recipe>();
            CreateMap<DietType, RecipeDTO>()
                .ForMember(dest => dest.DietTypes, act => act.MapFrom(src => src.DietTypeDescription))
                .ForMember(dest => dest.DietTypes, act => act.MapFrom(src => src.DietTypeId));

            // detailed
            CreateMap<Recipe, RecipeDetailsDTO>().ReverseMap();
            CreateMap<Recipe, CreateRecipeDTO>().ReverseMap();

            // Users
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            // ...

            // {...}
        }
    }
}
