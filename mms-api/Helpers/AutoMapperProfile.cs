using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Meetings;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<Attendees, Attendees>();
            CreateMap<Meetings, Meetings>();
            CreateMap<MappedAttendees, MappedAttendees>();
        }
    }
}