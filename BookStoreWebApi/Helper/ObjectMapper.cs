using AutoMapper;
using BookStoreWebApi.Domain.Models;
using BookStoreWebApi.DTO;

namespace BookStoreWebApi.Helper
{
    public class ObjectMapper : Profile
    {
        public ObjectMapper()
        {
            CreateMap<Books, BookModelDTO>().ReverseMap();
            CreateMap<SignUp, SignUpModelDTO>().ReverseMap();
            CreateMap<Login, LoginModelDTO>().ReverseMap();
        }
    }
}
