import React from 'react'

export default function OrderView({order}) {
  return (
    <div>
        <h4>{order.orderId}</h4>
        <h4>{order.costOrder}</h4>
        <h4>Дата вьезда {order.dateStart}</h4>
        <h4>Количевство дней {order.dayCount}</h4>
    </div>
  )
}
