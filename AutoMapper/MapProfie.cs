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
            CreateMap<Book, ReadBooksDtos>()
            .ForMember(n => n.Name, x => x.MapFrom(x => x.Authors!.Name));
            CreateMap<UpdateBookDtos, Book>();
            CreateMap<Book, ReadBookDto_Id>();
        }
    }
}