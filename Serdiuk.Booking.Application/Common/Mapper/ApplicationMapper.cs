using AutoMapper;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Domain.Dto;

namespace Serdiuk.Booking.Application.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Hotel, HotelInfoDto>()
                .ForMember(h => h.Id, c => c.MapFrom(d => d.Id))
                .ForMember(h => h.CanOrderNumber, c => c.MapFrom(d => d.CanOrderNumber))
                .ForMember(h => h.AvailableRooms, c => c.MapFrom(d => d.AvailableRooms))
                .ForMember(h => h.Image, c => c.MapFrom(d => d.Image))
                .ForMember(h => h.Name, c => c.MapFrom(d => d.Name))
                .ForMember(h => h.NumbersCount, c => c.MapFrom(d => d.NumbersCount))
                .ForMember(h => h.Street, c => c.MapFrom(d => d.Street));
        }
    }
}
