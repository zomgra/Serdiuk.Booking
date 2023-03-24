using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Domain.Dto;
using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Application.Hotels.GetByFilter
{
    /// <summary>
    /// Взять все отели подходящие под фильтр
    /// </summary>
    public class GetHotelsByFilterQuery : IRequest<Result<IEnumerable<HotelInfoDto>>>
    {
        /// <summary>
        /// Минимальная цена номера
        /// </summary>
        [JsonPropertyName("minCost")]
        public int MinCost { get; set; }
        /// <summary>
        /// Максимальная цена номера
        /// </summary>
        [JsonPropertyName("maxCost")]
        public int MaxCost { get; set; }
        /// <summary>
        /// Тип номера
        /// </summary>
        [JsonPropertyName("type")]
        public NumberType NumberType { get; set; }
    }
}
