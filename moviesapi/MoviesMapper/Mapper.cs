using AutoMapper;
using moviesapi.DAL.Dtos.Category;
using moviesapi.DAL.Dtos.Movie;
using moviesapi.DAL.Models;

namespace moviesapi.MoviesMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateCreateDto>().ReverseMap();

            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
            CreateMap<Movie, MovieUpdateCreateDto>().ReverseMap();
        }
    }
}