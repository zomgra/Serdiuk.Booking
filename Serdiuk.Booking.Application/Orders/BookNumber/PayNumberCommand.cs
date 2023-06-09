﻿using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Application.Numbers.BookNumber
{
    /// <summary>
    /// Команда оплаты номера
    /// </summary>
    public class PayNumberCommand : IRequest<Result>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Идентификатор отеля
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }
    }
}
