import React from 'react'
import { Link } from 'react-router-dom'

export default function HotelView({ hotel }) {
    return (
        <div className='py-3 px-3 pt-3 col-6 border-bottom' key={hotel.id}>
            <div className='pb-2'>
                <img alt=''className='rounded img-thumbnail' src={hotel.image} />
                <Link to={`/hotel/${hotel.id}`} className='py-1'>
                    {hotel.name}
                </Link>
            </div>
            <div>
                <span className='fas'>Улица: {hotel.street}</span>
            </div>
            <p>{hotel.details}</p>
            <div>
                Номеров
            </div>
            <div>
                {hotel.availableRooms} / {hotel.numbersCount}
            </div>
        </div>
    )
}
