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
                .ForMember(h => h.AvailableRooms, c => c.MapFrom(d => d.AvailableRooms))
                .ForMember(h => h.Image, c => c.MapFrom(d => d.Image))
                .ForMember(h => h.Name, c => c.MapFrom(d => d.Name))
                .ForMember(h => h.NumbersCount, c => c.MapFrom(d => d.NumbersCount))
                .ForMember(h => h.Details, c => c.MapFrom(d => d.Details))
                .ForMember(h => h.Street, c => c.MapFrom(d => d.Street));
            CreateMap<Order, OrderDto>()
                .ForMember(h => h.OrderId, c => c.MapFrom(d => d.OrderId))
                .ForMember(h => h.NumberCost, c => c.MapFrom(d => d.NumberCost))
                .ForMember(h => h.Status, c => c.MapFrom(d => d.Status))
                .ForMember(h => h.DateStart, c => c.MapFrom(d => d.DateStart.ToString("dd.MM.yyy")))
                .ForMember(h => h.DateEnd, c => c.MapFrom(d => d.DateEnd.ToString("dd.MM.yyyy")))
                .ForMember(h => h.DayCount, c => c.MapFrom(d => d.DayCount.Days.ToString()))
                .ForMember(h => h.CostOrder, c => c.MapFrom(d => d.CostOrder));
        }
    }
}
