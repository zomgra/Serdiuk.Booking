import React from 'react'
import { cancelOrderHandler, payOrderHandler } from '../../services/hotelsService'

export default function OrderView({ order }) {

    async function cancelOrder(id) {
        let result = await cancelOrderHandler(id)
        console.log(result);
    }
    async function payOrder(id) {
        let result = await payOrderHandler(id)
        console.log(result);
    }

    function getDetailButton(status, id) {
        if (status === 0)
            return (
                <div>
                    <button onClick={()=>payOrder(id)} className='btn btn-success'>Payed</button>
                    <button onClick={()=>cancelOrder(id)} className='btn btn-danger'>Cancel</button>
                </div>)
        else if (order.status === 1)
            return (
                <div>
                    <p className='text-success'>Заказ оплачен</p>
                </div>
            )
        else if (order.status === 2)
            return (
                <div>
                    <p className='text-info'>Заказ завершен</p>
                </div>
            )
        else if (order.status === 3)
            return (
                <div>
                    <p className='text-danger'>Заказ отменен</p>
                </div>
            )
    }

    return (
        <div>
            <h4>{order.orderId}</h4>
            <h4>{order.costOrder}</h4>
            <h4>Дата вьезда {order.dateStart}</h4>
            <h4>Количевство дней {order.dayCount}</h4>
            {getDetailButton(order.status, order.orderId)}
        </div>
    )
}
