import React, { useEffect, useState } from 'react'
import { getUserOrders } from '../../services/hotelsService'
import OrderView from './OrderView';

export default function OrderList() {

    const [orders, setOrders] = useState([])

    useEffect(() => {
        async function getOrders() {
            let orders = await getUserOrders();
            await setOrders(orders);
            console.log(orders);
        }
        getOrders();
    }, [])

    if (!orders) {
        return (
            <div>
                У вас нету заказов
            </div>)
    }

    return (
        <div className=''>
            <button onClick={()=>{window.location.href='/'}} className='btn btn-primary m-4'>К отелям</button>
            {orders.map((order) => <OrderView key={order.orderId} order={order}/>)}
        </div>
    )
}
