import React from 'react'
import { Link } from 'react-router-dom'

export default function HotelView({ hotel }) {
    return (
        <div className='row py-3 pt-3 border-bottom' key={hotel.id}>
            <div className='pb-2'>
                <img alt=''className='rounded img-thumbnail' src={hotel.image} />
                <Link to={`/hotel/${hotel.id}`} className='py-1'>
                    {hotel.name}
                </Link>
            </div>
            <div>
                <span className='fas'>Street: {hotel.street}</span>
            </div>
            <div>
                Numbers Count
            </div>
            <div>
                {hotel.availableRooms} / {hotel.numbersCount}
            </div>
        </div>
    )
}
