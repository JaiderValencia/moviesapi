using AutoMapper;
using moviesapi.DAL.Dtos.Category;
using moviesapi.DAL.Models;

namespace moviesapi.MoviesMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateCreateDto>().ReverseMap();
        }
    }
}