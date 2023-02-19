using AutoMapper;
using BookMinAPIs.DTO;
using BookMinAPIs.Models.Entity;
namespace BookMinAPIs.Automapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateBookDtos, Book>();
            CreateMap<Book, ReadBooksDtos>();
            CreateMap<UpdateBookDtos, Book>();
        }
    }
}